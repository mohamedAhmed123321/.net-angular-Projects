

var Item = {
    images: [],
    fileBase64: "",
    promises: [],

    // Function to convert image to base64
    getImageBase64: function (imgElement) {
        return new Promise(function (resolve, reject) {
            var canvas = document.createElement('canvas');
            canvas.width = imgElement.width; // Use original width
            canvas.height = imgElement.height;
            var ctx = canvas.getContext('2d');
            ctx.drawImage(imgElement, 0, 0, imgElement.width, imgElement.height); 
            var base64Data = canvas.toDataURL('image/png');
            resolve(base64Data.replace(/^data:image\/(png|jpg|jpeg);base64,/, ''));
        });
    },
    getVideoBase64: function (videoElement) {
        return new Promise((resolve, reject) => {
            if (!videoElement || !videoElement.src) {
                reject(new Error('No video source provided.'));
                return;
            }

            const xhr = new XMLHttpRequest();
            xhr.onload = function () {
                const reader = new FileReader();
                reader.onload = function () {
                    const base64Data = reader.result.split(',')[1];        // Extract Base64 data
                    resolve(base64Data); // Resolve the promise with the Base64 data
                };
                reader.onerror = function (error) {
                    reject(error); // Reject the promise if there's an error
                };
                reader.readAsDataURL(xhr.response); // Read the video file as a data URL
            };
            xhr.onerror = function (error) {
                reject(error); // Reject the promise if there's an error with XHR
            };
            xhr.open('GET', videoElement.src);
            xhr.responseType = 'blob'; // Set responseType to blob to handle binary data
            xhr.send();
        });
    },
    ItemData: function () {



        var imagesRows = document.querySelectorAll('#images-table-body tr');
        // Iterate over each row to update its identifier
        imagesRows.forEach(function (row, index) {

            var mediaCell = row.querySelector('td:first-child');
            var mediaElement = mediaCell.querySelector('img, video');
            debugger;
            let file;
            var id = parseInt(row.querySelector('#HiddenImgId').value);
            if (id === null || isNaN(id))
                id = 0;

            let isDefualt = false;
            var checkbox = row.querySelector('.checkbox');
            if (checkbox.checked)
                isDefualt = true;

            // Check if it's an image or video
            if (mediaElement && mediaElement.tagName.toLowerCase() === 'img') {
                let ImgBase;
                Item.promises.push(Item.getImageBase64(mediaElement)
                    .then(function (base64ImageData) {
                        // Use the base64ImageData here
                        Item.fileBase64 = base64ImageData;
                        var content = {
                            id: id,
                            file: Item.fileBase64,
                            isDefualt: isDefualt,
                        }
                        Item.images.push(content);
                    })
                    .catch(function (error) {
                        // Handle any errors that might occur during conversion
                        console.error('Error getting base64 image data:', error);
                    }));

            }


        });


        Promise.all(Item.promises)
            .then(function () {
                return Item.images;


            })
            .catch(function (error) {
                // Handle errors from any of the asynchronous operations
                console.error('Error processing images and videos:', error);
            });


    },

    //Post: function (ItemData) {
    //    console.log(ItemData)
    //    $.ajax({
    //        url: 'https://localhost:7038/api/Item/Post/',
    //        method: 'POST',
    //        contentType: 'application/json',
    //        data: JSON.stringify(ItemData),
    //        dataType: 'json',
    //        success: function (response) {
    //            // Handle success response


    //            if (response.isSuccess) {

    //                Swal.fire({
    //                    icon: 'success',
    //                    title: 'Success',
    //                    text: 'Saved successfully!',
    //                    showCancelButton: false,
    //                    confirmButtonText: 'OK',
    //                    allowOutsideClick: false, // Prevent closing the alert by clicking outside
    //                }).then((result) => {
    //                    if (result.isConfirmed) {
    //                        window.location.href = '/admin/Item/List'// Submit the form
    //                    }
    //                });
    //            }
    //            else {
    //                console.error('Error:', response.error);
    //                Swal.fire({
    //                    icon: 'error',
    //                    title: 'Failed',
    //                    text: 'something goes wrong',
    //                    showCancelButton: false,
    //                    confirmButtonText: 'OK',
    //                    allowOutsideClick: false, // Prevent closing the alert by clicking outside
    //                }).then((result) => {
    //                    if (result.isConfirmed) {
    //                        $('#MyForm').submit(); // Submit the form
    //                    }
    //                });
    //            }

    //        },
    //        error: function (xhr, status, error) {
    //            // Handle error\
    //            console.error('Error:', error);
    //            Swal.fire({
    //                icon: 'error',
    //                title: 'Failed',
    //                text: 'something goes wrong',
    //                showCancelButton: false,
    //                confirmButtonText: 'OK',
    //                allowOutsideClick: false, // Prevent closing the alert by clicking outside
    //            }).then((result) => {
    //                if (result.isConfirmed) {
    //                    $('#MyForm').submit(); // Submit the form
    //                }
    //            });




    //        }
    //    });
    //},

};




