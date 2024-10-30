var MyForm = {
    init: function () {
        document.getElementById('fileInput').addEventListener('change', this.handleFileInputChange);
        document.getElementById('descriptionForm').addEventListener('submit', this.handleSubmit);
    },

    handleFileInputChange: function () {
        var tbody = document.getElementById('images-table-body');
        var files = this.files;

        for (var i = 0; i < files.length; i++) {
            (function (file, index) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    if (file.type.startsWith('image/') || file.type.startsWith('video/')) {
                        var row = document.createElement('tr');
                        var mediaCell = document.createElement('td');
                        if (file.type.startsWith('image/')) {
                            if (!(file.size <= 10 * 1024 * 1024)) {
                                Swal.fire({
                                    icon: 'warning',
                                    title: 'Invalid File Type',
                                    text: 'Please select an image smaller than 10MB ',
                                });
                                return;
                            }
                            var img = document.createElement('img');
                            img.src = e.target.result;
                            img.classList.add('img-table');
                            img.style.width = '70px';
                            img.style.height = '75px';
                            img.setAttribute('id', index);
                            img.addEventListener('click', function () {

                                MyForm.displayMediaInModal(img.src, 'image');
                            });
                            mediaCell.appendChild(img);
                        } else if (file.type.startsWith('video/')) {
                            if (!(file.size <= 10485760)) {
                                Swal.fire({
                                    icon: 'warning',
                                    title: 'Invalid File Type',
                                    text: 'Please select a video smaller than 10MB. ',
                                });
                                return;
                            }
                            var video = document.createElement('video');
                            video.src = e.target.result;
                            video.classList.add('video-table');
                            video.style.width = '70px';
                            video.style.height = '75px';
                            video.setAttribute('id', index);
                            video.addEventListener('click', function () {

                                MyForm.displayMediaInModal(video.src, 'video');
                            });
                            mediaCell.appendChild(video);
                        }

                        var checkboxCell = document.createElement('td');
                        var checkboxDiv = document.createElement('div');
                        checkboxDiv.classList.add('form-check');
                        var checkboxLabel = document.createElement('label');
                        checkboxLabel.classList.add('form-check-label');
                        var checkbox = document.createElement('input');
                        checkbox.type = 'checkbox';
                        checkbox.classList.add('checkbox');
                        checkbox.addEventListener('change', function () {

                            MyForm.handleCheckboxChange(this);
                        });
                        var checkboxIcon = document.createElement('i');
                        checkboxIcon.classList.add('input-helper');
                        checkboxLabel.appendChild(checkbox);
                        checkboxLabel.appendChild(checkboxIcon);
                        var InputHiddenId = document.createElement('input');
                        InputHiddenId.type = 'hidden';
                        InputHiddenId.id = 'HiddenImgId'
                        InputHiddenId.value = '';
                        checkboxDiv.appendChild(InputHiddenId);
                        checkboxDiv.appendChild(checkboxLabel);
                        checkboxCell.appendChild(checkboxDiv);


                        var removeCell = document.createElement('td');
                        var removeButton = document.createElement('button');
                        removeButton.classList.add('btn', 'btn-gradient-danger', 'btn-sm');
                        removeButton.setAttribute('data-widget', 'remove');
                        removeButton.setAttribute('data-toggle', 'tooltip');
                        removeButton.type = 'button';
                        removeButton.setAttribute('title', 'Remove');
                        removeButton.addEventListener('click', function () {
                            MyForm.removeImage(row);
                        });
                        var removeIcon = document.createElement('i');
                        removeIcon.classList.add('fa', 'fa-trash');
                        removeButton.appendChild(removeIcon);
                        removeCell.appendChild(removeButton);

                        row.appendChild(mediaCell);
                        row.appendChild(checkboxCell);
                        row.appendChild(removeCell);

                        tbody.appendChild(row);
                        MyForm.updateIdentifiers();
                    } else {
                        Swal.fire({
                            icon: 'warning',
                            title: 'Invalid File Type',
                            text: 'Please select a valid image or video file.',
                        });
                    }
                };

                reader.readAsDataURL(file);
            })(files[i], i);
        }
    },

    displayMediaInModal: function (src, type) {
        if (type === 'image') {
            var img = new Image();
            img.src = src;
            img.style.maxWidth = '100%';
            img.style.height = '250px';
            img.style.width = '400px';
            img.style.margin = 'auto';

            MyForm.showModalContent(img);
        } else if (type === 'video') {
            var video = document.createElement('video');
            video.src = src;
            video.setAttribute('controls', '');
            video.style.maxWidth = '100%';
            video.style.height = '250px';
            video.style.width = '400px';
            video.style.margin = 'auto';
            MyForm.showModalContent(video);
        }
    },
    showModalContent: function (content) {
        // Create backdrop
        var backdrop = document.createElement('div');
        backdrop.classList.add('modal-backdrop');
        backdrop.style.backgroundColor = 'rgba(0, 0, 0, 0.5)';
        document.body.appendChild(backdrop);

        // Create modal container
        var modal = document.createElement('div');
        modal.id = 'myModal';
        modal.classList.add('modal');
        modal.style.display = 'flex';
        modal.style.alignItems = 'center';
        modal.style.justifyContent = 'center';
        modal.style.position = 'fixed';
        modal.style.top = '0';
        modal.style.bottom = '0';
        modal.style.left = '0';
        modal.style.right = '0';
        modal.style.zIndex = '9999';
        modal.style.overflow = 'auto';

        // Create modal content container
        var modalContent = document.createElement('div');
        modalContent.style.width = '450px';
        modalContent.style.height = '300px';
        modalContent.classList.add('modal-content');
        modalContent.appendChild(content);

        // Append content to modal
        modal.appendChild(modalContent);

        // Append modal to body
        document.body.appendChild(modal);

        // Function to close modal
        function closeModal() {
            modal.style.display = 'none';
            modal.remove();
            backdrop.remove();
        }

        // Create close button
        var closeButton = document.createElement('span');
        closeButton.classList.add('close');
        closeButton.innerHTML = '&times;';
        closeButton.style.position = 'absolute';
        closeButton.style.top = '-8px';
        closeButton.style.left = '8px'; // Adjust position here
        closeButton.style.cursor = 'pointer';
        closeButton.style.color = 'black';
        closeButton.style.fontSize = '30px';

        // Add close button click event listener
        closeButton.addEventListener('click', closeModal);

        // Append close button to modal content
        modalContent.appendChild(closeButton);

        // Close modal when clicking outside or pressing Escape
        backdrop.addEventListener('click', closeModal);
        document.addEventListener('keydown', function (event) {
            if (event.key === 'Escape') {
                closeModal();
            }
        });
    },


    moveRowUp: function (row) {
        if (row.nextElementSibling) {
            row.parentNode.insertBefore(row, row.nextElementSibling.nextElementSibling);
            MyForm.updateIdentifiers();
        }
    },

    moveRowDown: function (row) {
        if (row.previousElementSibling) {
            row.parentNode.insertBefore(row, row.previousElementSibling);
            MyForm.updateIdentifiers();
        }
    },

    updateIdentifiers: function () {
        var rows = document.querySelectorAll('#images-table-body tr');
        rows.forEach(function (row, index) {
            if (index === 0) {
                let upRow = row.querySelector('.up-arrow');
                if (upRow) upRow.style.display = 'none';
            } else row.querySelector('.up-arrow').style.display = 'inline';

            if (index === rows.length - 1) {
                let downRow = row.querySelector('.down-arrow');
                if (downRow) downRow.style.display = 'none';
            } else row.querySelector('.down-arrow').style.display = 'inline';

            var media = row.querySelector('img, video');
            media.id = index;
        });
    },

    removeImage: function (row) {
        // Show SweetAlert confirmation dialog
        Swal.fire({
            title: "Are you sure?",
            text: "Delete",
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "OK",
            cancelButtonText: "Cancel",
            buttonsStyling: false,
            customClass: {
                confirmButton: "btn btn-primary m-2", // Using 'btn-primary' class for OK button
                cancelButton: "btn btn-danger m-2", // Using 'btn-secondary' class for Cancel button
            },
        }).then((result) => {
            if (result.isConfirmed) {
                // Delete the corresponding row from the table body

                var id = row.querySelector('#HiddenImgId').value
                if (id !== "") {
                   /* window.location.href = '/admin/Item/DeleteItemImage/' + id;*/
                    $.ajax({
                        url: `/admin/Item/DeleteItemImage?id=${id}`,
                        type: 'POST',
                        dataType: 'json',
                        data: { Id: id },
                        success: function (response) {
                            row.parentNode.removeChild(row);
                            if (response) {
                                Swal.fire({
                                    icon: 'success',
                                    title: 'Success',
                                    text: 'Deleted successfully!',
                                    showCancelButton: false,
                                    confirmButtonText: 'OK',
                                    allowOutsideClick: false, // Prevent closing the alert by clicking outside
                                }).then((result) => {
                                    /*    window.location.reload();*/
                                });
                            }
                            else {

                                Swal.fire({
                                    icon: 'error',
                                    title: 'Failed',
                                    text: 'Not Deleted',
                                    showConfirmButton: false,
                                    timer: 1500 // Auto-dismiss alert after 1.5 seconds
                                });
                            }

                        },
                        error: function (xhr, status, error) {
                            // Handle error
                            Swal.fire({
                                icon: 'error',
                                title: 'Failed',
                                text: 'Not Deleted',
                                showConfirmButton: false,
                                timer: 1500 // Auto-dismiss alert after 1.5 seconds
                            });
                            if (xhr.status === 400) {
                                console.error('Bad request:', error);
                                // Handle bad request response here
                                return;
                            }

                        }
                    });
                }
                else {
                    row.parentNode.removeChild(row);
                    MyForm.updateIdentifiers();
                    Swal.fire({
                        icon: 'success',
                        title: 'Success',
                        text: 'Deleted successfully!',
                        showCancelButton: false,
                        confirmButtonText: 'OK',
                        allowOutsideClick: false, // Prevent closing the alert by clicking outside
                    }).then((result) => {

                    });
                }
            } else {
                Swal.fire({
                    title: " not deleted",
                    icon: "info",
                });
            }
        });
    },

    handleCheckboxChange: function (checkbox) {
        if (checkbox.checked) {
            var checkboxes = document.querySelectorAll('.checkbox');
            checkboxes.forEach(function (otherCheckbox) {
                if (otherCheckbox !== checkbox) {
                    otherCheckbox.checked = false;
                }
            });
        }
    },

    addDescriptionField: function () {
        let isValidDesc = MyForm.ValidateDescription();
        if (!isValidDesc) return;
        var descriptionRow = document.createElement('tr');
        // Create elements for English description
        var enDescription = document.createElement('td');
        var enDescriptionDiv = document.createElement('div');
        enDescriptionDiv.classList.add('form-group', 'col-md-5', 'descriptios');
        enDescriptionDiv.style.width = '100%';
        var enDescriptionTextarea = document.createElement('textarea');
        enDescriptionTextarea.id = 'En Description';
        enDescriptionTextarea.type = 'text';
        enDescriptionTextarea.classList.add('form-control');
        enDescriptionTextarea.placeholder = 'EbDiscription';
        var inputId = document.createElement('input');
        inputId.id = 'DescriptionId';
        inputId.type = 'hidden';
        inputId.value = '';
        enDescriptionDiv.appendChild(inputId);
        enDescriptionDiv.appendChild(enDescriptionTextarea);
        var enSpan = document.createElement('span');
        enSpan.textContent = 'This field is required';
        enSpan.style.color = 'crimson';
        enSpan.style.display = 'none';
        enSpan.id = 'EnDescription';
        enDescriptionDiv.appendChild(enSpan);
        enDescription.appendChild(enDescriptionDiv);

        // Create elements for Arabic description
        var arDescription = document.createElement('td');
        var arDescriptionDiv = document.createElement('div');
        arDescriptionDiv.classList.add('form-group', 'col-md-5', 'descriptios');
        arDescriptionDiv.style.width = '100%';
        var arDescriptionTextarea = document.createElement('textarea');
        arDescriptionTextarea.id = 'ArDescription';
        arDescriptionTextarea.type = 'text';
        arDescriptionTextarea.classList.add('form-control');
        arDescriptionTextarea.placeholder = 'Ar Dicription';
        arDescriptionDiv.appendChild(arDescriptionTextarea);
        var arSpan = document.createElement('span');
        arSpan.textContent = 'This field is required';
        arSpan.style.color = 'crimson';
        arSpan.style.display = 'none';
        arSpan.id = 'ArDescription';
        arDescriptionDiv.appendChild(arSpan);
        arDescription.appendChild(arDescriptionDiv);

        // Create elements for description order and actions
        var descriptionOrder = document.createElement('td');
        var upArrow = document.createElement('button');
        upArrow.classList.add('btn', 'btn-sm', 'btn-primary', 'up-arrow');
        upArrow.style.margin = '5px';
        upArrow.type = 'button';
        upArrow.innerHTML = '&uarr;';
        upArrow.addEventListener('click', function () {
            MyForm.moveDescriptionDown(descriptionRow);
        });
        var downArrow = document.createElement('button');
        downArrow.classList.add('btn', 'btn-sm', 'btn-primary', 'down-arrow');
        downArrow.style.margin = '5px';
        downArrow.type = 'button';
        downArrow.innerHTML = '&darr;';
        downArrow.addEventListener('click', function () {
            MyForm.moveDescriptionUp(descriptionRow);
        });
        var actions = document.createElement('td');
        var removeButton = document.createElement('button');
        removeButton.classList.add('btn', 'btn-gradient-danger', 'btn-sm');
        removeButton.setAttribute('data-widget', 'remove');
        removeButton.type = 'button'
        removeButton.setAttribute('data-toggle', 'tooltip');
        removeButton.setAttribute('title', 'Remove');
        removeButton.addEventListener('click', function () {
            MyForm.removeDescription(descriptionRow);
        });
        var removeIcon = document.createElement('i');
        removeIcon.classList.add('fa', 'fa-trash');
        removeButton.appendChild(removeIcon);

        // Append elements to corresponding cells
        descriptionOrder.appendChild(upArrow);
        descriptionOrder.appendChild(downArrow);
        actions.appendChild(removeButton);

        // Append cells to the row
        descriptionRow.appendChild(arDescription);
        descriptionRow.appendChild(enDescription);
        descriptionRow.appendChild(descriptionOrder);
        descriptionRow.appendChild(actions);

        // Append the row to the description section
        document.getElementById('descriptionSection').appendChild(descriptionRow);
        MyForm.updateDescription();
    },

    moveDescriptionUp: function (row) {
        if (row.nextElementSibling) {
            row.parentNode.insertBefore(row, row.nextElementSibling.nextElementSibling);
            MyForm.updateDescription();
        }
    },

    moveDescriptionDown: function (row) {
        if (row.previousElementSibling) {
            row.parentNode.insertBefore(row, row.previousElementSibling);
            MyForm.updateDescription();
        }
    },

    updateDescription: function () {
        var rows = document.querySelectorAll('#descriptionSection tr');
        rows.forEach(function (row, index) {
            if (index === 0) {
                let upRow = row.querySelector('.up-arrow');
                if (upRow) upRow.style.display = 'none';
            } else row.querySelector('.up-arrow').style.display = 'inline';

            if (index === rows.length - 1) {
                let downRow = row.querySelector('.down-arrow');
                if (downRow) downRow.style.display = 'none';
            } else row.querySelector('.down-arrow').style.display = 'inline';

            var textarea = row.querySelector('textarea');
            textarea.id = index;
        });
    },

    removeDescription: function (row) {
        Swal.fire({
            title: "Are you sure?",
            text: "Delete",
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "OK",
            cancelButtonText: "Cancel",
            buttonsStyling: false,
            customClass: {
                confirmButton: "btn btn-primary m-2",
                cancelButton: "btn btn-danger m-2",
            },
        }).then((result) => {
            if (result.isConfirmed) {

                var id = row.querySelector('#DescriptionId').value
                if (id !== "") {

                    $.ajax({
                        url: 'https://localhost:7038/api/Page/DeleteDescription/' + id,
                        method: 'POST',
                        contentType: 'application/json',

                        success: function (response) {
                            row.parentNode.removeChild(row);
                            MyForm.updateDescription();
                            if (response) {
                                Swal.fire({
                                    icon: 'success',
                                    title: 'Success',
                                    text: 'Deleted successfully!',
                                    showCancelButton: false,
                                    confirmButtonText: 'OK',
                                    allowOutsideClick: false, // Prevent closing the alert by clicking outside
                                }).then((result) => {
                                    /*   window.location.reload();*/
                                });
                            }
                            else {

                                Swal.fire({
                                    icon: 'error',
                                    title: 'Failed',
                                    text: 'Not Deleted',
                                    showConfirmButton: false,
                                    timer: 1500 // Auto-dismiss alert after 1.5 seconds
                                });
                            }

                        },
                        error: function (xhr, status, error) {
                            // Handle error
                            Swal.fire({
                                icon: 'error',
                                title: 'Failed',
                                text: 'Not Deleted',
                                showConfirmButton: false,
                                timer: 1500 // Auto-dismiss alert after 1.5 seconds
                            });
                            if (xhr.status === 400) {
                                console.error('Bad request:', error);
                                // Handle bad request response here
                                return;
                            }

                        }
                    });
                }
                else {
                    row.parentNode.removeChild(row);
                    MyForm.updateDescription();
                    Swal.fire({
                        icon: 'success',
                        title: 'Success',
                        text: 'Deleted successfully!',
                        showCancelButton: false,
                        confirmButtonText: 'OK',
                        allowOutsideClick: false, // Prevent closing the alert by clicking outside
                    }).then((result) => {

                    });
                }

            }
            else {
                Swal.fire({
                    title: "Description not deleted",
                    icon: "info",
                });

            }
        });
    },

    handleSubmit: function (event) {

        var rows = document.querySelectorAll('#images-table-body tr img');
        if (rows.length === 0) {
            Swal.fire({
                title: 'error',
                text: 'No Image Selected',
                icon: 'warning',
                confirmButtonText: 'OK',
                buttonsStyling: false,
                customClass: {
                    confirmButton: 'btn btn-primary m-2'
                }
            });
            event.preventDefault();
            return;
        }

        var checkboxes = document.querySelectorAll('.checkbox');
        if (checkboxes.length === 0) {
            Swal.fire({
                title: 'Please select default image',
                icon: 'warning',
                confirmButtonText: 'OK',
                buttonsStyling: false,
                customClass: {
                    confirmButton: 'btn btn-primary m-2'
                }
            });
            event.preventDefault();
            return;
        }

        var isDefault = false;
        rows.forEach(function (rows, index) {
            var imgDiv = rows.parentNode.parentNode;
            var checkbox = imgDiv.querySelector('.checkbox');
            if (checkbox.checked) {
                isDefault = true;
                return;
            }
        });

        if (!isDefault) {
            Swal.fire({
                title: 'Please select default image',
                icon: 'warning',
                confirmButtonText: 'OK',
                buttonsStyling: false,
                customClass: {
                    confirmButton: 'btn btn-primary m-2'
                }
            });
            event.preventDefault();
            return;
        }
        Item.ItemData();
        Promise.all(Item.promises)
            .then(function () {
                document.getElementById("myStringImages").value = JSON.stringify(Item.images);

            })
            .catch(function (error) {
                // Handle errors from any of the asynchronous operations
                console.error('Error processing images and videos:', error);
            });

        // Assuming this function exists
    },

    ValidateDescription: function () {
        let isValid = true;
        let descriptions = document.getElementsByClassName("descriptios");
        for (var i = descriptions.length - 1; i >= 0; i--) {
            var value = descriptions[i].querySelector('textarea');
            var spanElement = $(descriptions[i]).find('span').get(0);
            if (value.value == null || value.value == "" || value.value == "null" || value.selectedIndex === -1) {
                value.scrollIntoView();
                $(spanElement).css('display', 'block');
                isValid = false;
            } else {
                $(spanElement).css('display', 'none');
            }
        }
        return isValid;
    },

    ValidateArticleData: function () {
        let isValid = true;
        let articleData = document.getElementsByClassName("ArticleData");
        for (var i = articleData.length - 1; i >= 0; i--) {
            var value = articleData[i].querySelector('input, textarea');
            var spanElement = $(articleData[i]).find('span').get(0);
            if (value.value == null || value.value == "" || value.value == "null" || value.selectedIndex === -1) {
                value.scrollIntoView();
                $(spanElement).css('display', 'block');
                isValid = false;
            } else {
                $(spanElement).css('display', 'none');
            }
        }
        return isValid;
    },
    DrawImages: function (images) {
        console.log(images);  
        var tbody = document.getElementById('images-table-body');

        for (var i = 0; i < images.length; i++) {
            var row = document.createElement('tr');
            var mediaCell = document.createElement('td');
            var img = document.createElement('img');
            img.src = '/Uploads/Item/' + images[i].ImageName;
            img.classList.add('img-table');
            img.style.width = '70px';
            img.style.height = '75px';
            img.setAttribute('id', i);
            img.addEventListener('click', (function (src) {
                return function () {MyForm.displayMediaInModal(src, 'image');};
            })(img.src));
            mediaCell.appendChild(img);



            var checkboxCell = document.createElement('td');
            var checkboxDiv = document.createElement('div');
            checkboxDiv.classList.add('form-check');
            var checkboxLabel = document.createElement('label');
            checkboxLabel.classList.add('form-check-label');
            var checkbox = document.createElement('input');
            checkbox.type = 'checkbox';
            checkbox.classList.add('checkbox');

            checkbox.addEventListener('change', function () {

                MyForm.handleCheckboxChange(this);
            });


            var checkboxIcon = document.createElement('i');
            checkboxIcon.classList.add('input-helper');
            checkboxLabel.appendChild(checkbox);
            checkboxLabel.appendChild(checkboxIcon);
            var InputHiddenId = document.createElement('input');
            InputHiddenId.type = 'hidden';
            InputHiddenId.id = 'HiddenImgId'
            InputHiddenId.value = images[i].ImageId;
            checkboxDiv.appendChild(InputHiddenId);
            checkboxDiv.appendChild(checkboxLabel);
            checkboxCell.appendChild(checkboxDiv);



            var removeCell = document.createElement('td');
            var removeButton = document.createElement('button');
            removeButton.classList.add('btn', 'btn-gradient-danger', 'btn-sm');
            removeButton.setAttribute('data-widget', 'remove');
            removeButton.setAttribute('data-toggle', 'tooltip');
            removeButton.type = 'button';
            removeButton.setAttribute('title', 'Remove');
            removeButton.addEventListener('click', (function (row) {
                return function () {
                    MyForm.removeImage(row);
                };
            })(row));

            var removeIcon = document.createElement('i');
            removeIcon.classList.add('fa', 'fa-trash');
            removeButton.appendChild(removeIcon);
            removeCell.appendChild(removeButton);

            row.appendChild(mediaCell);
            row.appendChild(checkboxCell);
            row.appendChild(removeCell);

            tbody.appendChild(row);
        }

    },
    DrawDescription: function (description) {
        for (var i = 0; i < description.length; i++) {
            var descriptionRow = document.createElement('tr');
            descriptionRow.id = 'descriptionRow';
            var enDescription = document.createElement('td');
            var enDescriptionDiv = document.createElement('div');
            enDescriptionDiv.classList.add('form-group', 'col-md-5', 'descriptios');
            enDescriptionDiv.style.width = '100%';
            var enDescriptionTextarea = document.createElement('textarea');
            enDescriptionTextarea.id = 'En Description';
            enDescriptionTextarea.type = 'text';
            enDescriptionTextarea.value = description[i].enContent;

            enDescriptionTextarea.classList.add('form-control');
            enDescriptionTextarea.placeholder = 'En Discription';
            var inputId = document.createElement('input');
            inputId.id = 'DescriptionId';
            inputId.type = 'hidden';
            inputId.value = description[i].id;
            enDescriptionDiv.appendChild(inputId);
            enDescriptionDiv.appendChild(enDescriptionTextarea);
            var enSpan = document.createElement('span');
            enSpan.textContent = 'This field is required';
            enSpan.style.color = 'crimson';
            enSpan.style.display = 'none';
            enSpan.id = 'EnDescription';
            enDescriptionDiv.appendChild(enSpan);
            enDescription.appendChild(enDescriptionDiv);

            // Create elements for Arabic description
            var arDescription = document.createElement('td');
            var arDescriptionDiv = document.createElement('div');
            arDescriptionDiv.classList.add('form-group', 'col-md-5', 'descriptios');
            arDescriptionDiv.style.width = '100%';
            var arDescriptionTextarea = document.createElement('textarea');
            arDescriptionTextarea.id = 'ArDescription';
            arDescriptionTextarea.type = 'text';
            arDescriptionTextarea.value = description[i].arContent;
            arDescriptionTextarea.classList.add('form-control');
            arDescriptionTextarea.placeholder = 'Ar Dicription';
            arDescriptionDiv.appendChild(arDescriptionTextarea);
            var arSpan = document.createElement('span');
            arSpan.textContent = 'This field is required';
            arSpan.style.color = 'crimson';
            arSpan.style.display = 'none';
            arSpan.id = 'ArDescription';
            arDescriptionDiv.appendChild(arSpan);
            arDescription.appendChild(arDescriptionDiv);

            // Create elements for description order and actions
            var descriptionOrder = document.createElement('td');
            var upArrow = document.createElement('button');
            upArrow.classList.add('btn', 'btn-sm', 'btn-primary', 'up-arrow');
            upArrow.style.margin = '5px';
            upArrow.type = 'button';
            upArrow.innerHTML = '&uarr;';
            upArrow.addEventListener('click', (function (row) {
                return function () {
                    MyForm.moveDescriptionDown(row);
                };
            })(descriptionRow));
            var downArrow = document.createElement('button');
            downArrow.classList.add('btn', 'btn-sm', 'btn-primary', 'down-arrow');
            downArrow.style.margin = '5px';
            downArrow.type = 'button';
            downArrow.innerHTML = '&darr;';
            downArrow.addEventListener('click', (function (row) {
                return function () {
                    MyForm.moveDescriptionUp(row);
                };
            })(descriptionRow));
            var actions = document.createElement('td');
            var removeButton = document.createElement('button');
            removeButton.classList.add('btn', 'btn-gradient-danger', 'btn-sm');
            removeButton.setAttribute('data-widget', 'remove');
            removeButton.type = 'button'
            removeButton.setAttribute('data-toggle', 'tooltip');
            removeButton.setAttribute('title', 'Remove');
            removeButton.addEventListener('click', (function (row) {
                return function () {
                    MyForm.removeDescription(row);
                };
            })(descriptionRow));
            var removeIcon = document.createElement('i');
            removeIcon.classList.add('fa', 'fa-trash');
            removeButton.appendChild(removeIcon);

            // Append elements to corresponding cells
            descriptionOrder.appendChild(upArrow);
            descriptionOrder.appendChild(downArrow);
            actions.appendChild(removeButton);

            // Append cells to the row
            descriptionRow.appendChild(arDescription);
            descriptionRow.appendChild(enDescription);
            descriptionRow.appendChild(descriptionOrder);
            descriptionRow.appendChild(actions);

            // Append the row to the description section
            document.getElementById('descriptionSection').appendChild(descriptionRow);
            MyForm.updateDescription();
        }
    }

};

// Initialize the form functionality

