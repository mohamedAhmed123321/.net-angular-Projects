using Domains.Tables;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace E_commerce.Utlities
{
    public static class Helper
    {
        public static string UploadImage(string base64Images, string folderName, out bool IsImage)
        {

            IsImage = Helper.IsImageFile(base64Images);
            if (!IsImage)
                return "Please enter valid image";
            string ImageName = Guid.NewGuid() + Helper.GetImageExtensionFromBase64(base64Images);

            var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads/" + folderName, ImageName);

            System.IO.File.WriteAllBytes(filePaths, Convert.FromBase64String(base64Images));

            return ImageName;

        }
        public static string UploadImageAndCheck(string base64Images, string Image, string folderName, out bool IsImage)
        {
            if (string.IsNullOrEmpty(Image) && (base64Images == null))
            {
                IsImage = false;
                return "Please upload an image";
            }

            if (base64Images != null)
            {
                IsImage = Helper.IsImageFile(base64Images);
                if (!IsImage)
                    return "Please enter valid image";

                string ImageName = Guid.NewGuid() + Helper.GetImageExtensionFromBase64(base64Images);

                var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads/" + folderName, ImageName);

                System.IO.File.WriteAllBytes(filePaths, Convert.FromBase64String(base64Images));
                return ImageName;
            }
            IsImage = true;
            return Image;

        }
        public static string UploadVidoe(string video, string folderName, out bool IsImage)
        {
            try
            {
                IsImage = Helper.IsValidBase64(video);
                if (!IsImage)
                    return "Please enter valid video";
                IsImage = Helper.IsVidoe(video);
                if (!IsImage)
                    return "Please enter valid video";
                string ImageName = Guid.NewGuid() + Helper.GetVidoeExtensionFromBase64(video);

                var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads/" + folderName, ImageName);

                System.IO.File.WriteAllBytes(filePaths, Convert.FromBase64String(video));

                return ImageName;
            }
            catch (Exception ex)
            {
                IsImage = false;
                return "";
            }

        }
        public static async Task<(string message, bool isValid)> UploadImage(List<IFormFile> Files, string Image , string folderName)
        {
            if (string.IsNullOrEmpty(Image) && (Files == null || Files.Count == 0))
            {
                return ("Please upload an image.",false);
            }
  

            
            foreach (var file in Files)
            { 
                if (file.Length > 0)
                {
                    bool IsValid = ValidateFiles(Files);
                    if (!IsValid)
                        return ("Please enter valid image", false);

                    string ImageName = Guid.NewGuid().ToString() + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + ".jpg";
                    var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads/" + folderName, ImageName);
                    using (var stream = System.IO.File.Create(filePaths))
                    {
                        await file.CopyToAsync(stream);
                        return (ImageName,true);
                    }
                }
            }
            return (Image,true);
        }
        public static async Task<string> UploadCv(List<IFormFile> Files, string folderName)
        {
            foreach (var file in Files)
            {
                if (file.Length > 0)
                {
                    string Cv = Guid.NewGuid().ToString() + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + ".pdf";
                    var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads/" + folderName, Cv);
                    using (var stream = System.IO.File.Create(filePaths))
                    {
                        await file.CopyToAsync(stream);
                        return Cv;
                    }
                }
            }
            return string.Empty;
        }
        public static void SendEmail(string recipientEmail)
        {
            try
            {
                // Set up the email message
                MailMessage message = new MailMessage();
                message.From = new MailAddress("mohamedahmedsalama1234567@gmail.com"); // Sender's email address
                message.To.Add(recipientEmail); // Recipient's email address
                message.Subject = "Job Offer"; // Subject of the email
                message.Body = "About Job"; // Email content

                // Configure SMTP client (assuming Gmail SMTP settings)
                SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net");
                smtpClient.Port = 465;
                smtpClient.Credentials = new NetworkCredential("mohamedahmedsalama1234567@gmail.com", "mohamed 0$"); // Sender's email credentials
                smtpClient.EnableSsl = true;

                // Send the email
                smtpClient.Send(message);

                Console.WriteLine("Email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Email not sent");

            }
        }
        public static bool IsImageFile(string base64String)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(base64String);

                // Check the magic numbers for common image formats
                if (bytes.Length > 2 &&
                    (bytes[0] == 0xFF && bytes[1] == 0xD8) ||   // JPEG
                    (bytes[0] == 0x89 && bytes[1] == 0x50) ||   // PNG
                    (bytes[0] == 0x47 && bytes[1] == 0x49) ||   // GIF
                    (bytes[0] == 0x42 && bytes[1] == 0x4D))     // BMP
                {
                    return true;
                }

                return false;
            }
            catch
            {
                return false; // Invalid base64 string
            }
        }
        public static bool IsVidoe(string base64String)
        {

            try
            {
                byte[] bytes = Convert.FromBase64String(base64String);
                //Console.WriteLine("Decoded Bytes:");
                //foreach (byte b in bytes)
                //{
                //    Console.WriteLine(b.ToString("X2") + " "); // Print byte in hexadecimal format
                //}
                if (bytes.Length >= 12 &&
           bytes[4] == 0x66 &&
           bytes[5] == 0x74 &&
           bytes[6] == 0x79 &&
           bytes[7] == 0x70 &&    // 'ftyp'
           bytes[8] == 0x69 &&
           bytes[9] == 0x73 &&
           bytes[10] == 0x6F &&
           bytes[11] == 0x6D)     // 'isom'
                {
                    return true;
                }

                // Check if the bytes start with the AVI file signature
                else if (bytes.Length >= 12 &&
              bytes[0] == 0x52 && // 'R'
              bytes[1] == 0x49 && // 'I'
              bytes[2] == 0x46 && // 'F'
              bytes[3] == 0x46 && // 'F'
              bytes[8] == 0x41 && // 'A'
              bytes[9] == 0x56 && // 'V'
              bytes[10] == 0x49 && // 'I'
              bytes[11] == 0x20)    // space
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false; // Invalid base64 string
            }

        }
        private static bool IsValidBase64(string base64String)
        {
            return Regex.IsMatch(base64String, @"^[a-zA-Z0-9\+/]*={0,2}$");
        }
        public static bool ValidateFiles(List<IFormFile> files)
        {

            foreach (var file in files)
            {
                if (IsFileValid(file))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsFileValid(IFormFile file)
        {
            // Check if file exists
            if (file == null || file.Length == 0)
            {
                return false;
            }

            // Check file extension (optional)
            if (!IsImageExtension(Path.GetExtension(file.FileName)))
            {
                return false;
            }

            // Check if file size is less than or equal to 10 MB
            if (file.Length > 10 * 1024 * 1024) // 10 MB in bytes
            {
                return false;
            }
            if (!(file.ContentType.StartsWith("image/", StringComparison.OrdinalIgnoreCase)))
                return false;

            return true;
        }

        private static bool IsImageExtension(string extension)
        {
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };
            return Array.Exists(allowedExtensions, ext => ext.Equals(extension, StringComparison.OrdinalIgnoreCase));
        }
        public static string ValidateBase64Images(List<string> base64Images)
        {
            foreach (var base64Image in base64Images)
            {

                // Example: Validate image size
                // In base64 encoding, the image data length can be calculated from the length of the decoded byte array
                var base64Data = base64Image.Split(',')[1]; // Remove the data URI scheme prefix
                var bytes = Convert.FromBase64String(base64Data);
                if (bytes.Length > 10 * 1024 * 1024) // 10 MB limit
                {
                    return "Image size exceeds the maximum allowed size (10 MB)."; // Return validation error
                }


            }

            // If all validations pass for all base64 images, return an empty string (indicating no validation errors)
            return "";
        }
        public static string GetImageExtensionFromBase64(string base64String)
        {
            // Decode the base64 string
            byte[] bytes = Convert.FromBase64String(base64String);

            // Determine the file format based on the header bytes
            if (IsJpeg(bytes))
            {
                return ".jpg";
            }
            else if (IsPng(bytes))
            {
                return ".png";
            }
            else if (IsGif(bytes))
            {
                return ".gif";
            }
            else if (IsBmp(bytes))
            {
                return ".bmp";
            }
            else
            {
                // Unknown file format or not supported
                return null;
            }
        }
        public static string GetVidoeExtensionFromBase64(string base64String)
        {
            // Decode the base64 string
            byte[] bytes = Convert.FromBase64String(base64String);

            // Determine the file format based on the header bytes

            if (IsMp4(bytes))
            {
                return ".mp4";
            }
            else if (IsAvi(bytes))
            {
                return ".avi";
            }
            else if (IsMov(bytes))
            {
                return ".mov";
            }
            else
            {
                // Unknown file format or not supported
                return null;
            }
        }
        private static bool IsJpeg(byte[] bytes)
        {
            // Check if the file starts with the JPEG magic number
            return bytes.Length >= 2 && bytes[0] == 0xFF && bytes[1] == 0xD8;
        }

        private static bool IsPng(byte[] bytes)
        {
            // Check if the file starts with the PNG magic number
            return bytes.Length >= 8 &&
                   bytes[0] == 0x89 &&
                   bytes[1] == 0x50 &&
                   bytes[2] == 0x4E &&
                   bytes[3] == 0x47 &&
                   bytes[4] == 0x0D &&
                   bytes[5] == 0x0A &&
                   bytes[6] == 0x1A &&
                   bytes[7] == 0x0A;
        }

        private static bool IsGif(byte[] bytes)
        {
            // Check if the file starts with the GIF magic number
            return bytes.Length >= 6 &&
                   (bytes[0] == 0x47 && bytes[1] == 0x49 && bytes[2] == 0x46 && bytes[3] == 0x38) &&
                   (bytes[4] == 0x37 || bytes[4] == 0x39) && bytes[5] == 0x61;
        }

        private static bool IsBmp(byte[] bytes)
        {
            // Check if the file starts with the BMP magic number
            return bytes.Length >= 2 && bytes[0] == 0x42 && bytes[1] == 0x4D;
        }

        // Add methods to identify video formats (MP4, AVI, MOV) using magic numbers

        private static bool IsMp4(byte[] bytes)
        {
            // Check if the file starts with the MP4 file signature "ftypisom"
            return bytes.Length >= 12 &&
                   bytes[4] == 0x66 && // 'f'
                   bytes[5] == 0x74 && // 't'
                   bytes[6] == 0x79 && // 'y'
                   bytes[7] == 0x70 && // 'p'
                   bytes[8] == 0x69 && // 'i'
                   bytes[9] == 0x73 && // 's'
                   bytes[10] == 0x6F && // 'o'
                   bytes[11] == 0x6D;  // 'm'
        }


        private static bool IsAvi(byte[] bytes)
        {
            // Check if the file starts with the AVI file signature "RIFFAVI "
            return bytes.Length >= 12 &&
                   bytes[0] == 0x52 && // 'R'
                   bytes[1] == 0x49 && // 'I'
                   bytes[2] == 0x46 && // 'F'
                   bytes[3] == 0x46 && // 'F'
                   bytes[8] == 0x41 && // 'A'
                   bytes[9] == 0x56 && // 'V'
                   bytes[10] == 0x49 && // 'I'
                   bytes[11] == 0x20;  // space
        }


        private static bool IsMov(byte[] bytes)
        {
            // Check if the file starts with the MOV file signature "ftyp" or "moov"
            return bytes.Length >= 4 &&
                   (bytes[0] == 0x66 && bytes[1] == 0x74 && bytes[2] == 0x79 && bytes[3] == 0x70 || // "ftyp" for MOV
                    bytes[0] == 0x6D && bytes[1] == 0x6F && bytes[2] == 0x6F && bytes[3] == 0x76);   // "moov" for MOV
        }

    }
}
