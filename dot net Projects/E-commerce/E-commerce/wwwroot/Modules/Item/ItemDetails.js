

var ClsItemDetails = {
    pageSize: 12,
    totalPage: 3,
    currentPage: 1,
    startPage: 1,
    endPage: 0,

    categoryName: '',
    title: '',
    minPrice: 0,
    maxPrice: 1500,
    ramSize: 4,
    getData: function (pageNumber) {
        var loader = document.getElementById('loader-background');


        var requestData = {
            pageNumber: pageNumber,
            count: ClsItemDetails.pageSize,
            title: ClsItemDetails.title,
            ramSize: ClsItemDetails.ramSize,
            categoryName: ClsItemDetails.categoryName,
            MinPrice: ClsItemDetails.minPrice,
            MaxPrice: ClsItemDetails.maxPrice
        };
        $.ajax({
            url: 'https://localhost:7115/api/ApiItem/GetFilteredItem/',
            method: 'Post',
            contentType: 'application/json',
            data: JSON.stringify(requestData),
            dataType: 'json',
            success: function (data) {
                if (data.data.length === 0) {
                    ClsItemDetails.renderData(data.data);
                    loader.style.display = 'none';
                    return;
                }

                ClsItemDetails.totalPage = data.data[0].totalPages;
                ClsItemDetails.renderData(data.data);
                 ClsItemDetails.createPagination(parseInt(ClsItemDetails.totalPage));
                loader.style.display = 'none';

            },
            error: function () {
                // Handle error
                console.log("error")
                loader.style.display = 'none';
            }
        });
    },
    renderData: function (data) {

        var itemsPerPage = ClsItemDetails.pageSize;
        var totalItems = ClsItemDetails.totalPage;
        var innerrText = "1-" + itemsPerPage;
        $('#rangeStart').text(innerrText);
        $('#rangeEnd').text(totalItems);

        if (data.length === 0) {
            var d1 = document.getElementById('ItemArea');
            d1.innerHTML = "";
            var paginationContainer = document.getElementById('ItemPagination');
            var paginationList = paginationContainer.querySelector('ul');
            paginationList.innerHTML = '';
            return
        }
        var htmlData = "";
        for (var i = 0; i < data.length; i++) {
            htmlData += ClsItemDetails.DrawItem(data[i]);
        }

        var d1 = document.getElementById('ItemArea');
        d1.innerHTML = htmlData;
    },
    DrawItem: function (item) {
        // Your existing DrawItem function remains unchanged
        // ...
        var data = `
                     <div class="col-xl-3 col-6 col-grid-box">
                                                    <div class="product-box">
                                                        <div class="img-wrapper">
                                                            <div class="front">
                                                                <a href="/Item/ItemDetails?id=${item.itemId}"><img src="/Uploads/Item/${item.imageName}" class="img-fluid blur-up lazyload bg-img" alt=""></a>
                                                            </div>
                                                            <div class="back">
                                                                <a href="/Item/ItemDetails?id=${item.itemId}"><img src="/Uploads/Item/${item.imageName}" class="img-fluid blur-up lazyload bg-img" alt=""></a>
                                                            </div>
                                                            <div class="cart-info cart-wrap">
                                                                <button data-toggle="modal" data-target="#addtocart" title="Add to cart"><i
                                                                        class="ti-shopping-cart"></i></button> <a href="javascript:void(0)" title="Add to Wishlist"><i
                                                                        class="ti-heart" aria-hidden="true"></i></a> <a href="#" data-toggle="modal" data-target="#quick-view" title="Quick View"><i
                                                                        class="ti-search" aria-hidden="true"></i></a> <a href="compare.html" title="Compare"><i
                                                                        class="ti-reload" aria-hidden="true"></i></a>
                                                            </div>
                                                        </div>
                                                        <div class="product-detail">
                                                            <div>
                                                                <div class="rating"><i class="fa fa-star"></i> <i class="fa fa-star"></i> <i class="fa fa-star"></i> <i class="fa fa-star"></i> <i class="fa fa-star"></i></div>
                                                                <a href="product-page(no-sidebar).html">
                                                                    <h6>${item.itemName}</h6>
                                                                </a>
                                                                <p>${item.description}
                                                                </p>
                                                                <h4>$${item.salesPrice}</h4>
                                                                <ul class="color-variant">
                                                                    <li class="bg-light0"></li>
                                                                    <li class="bg-light1"></li>
                                                                    <li class="bg-light2"></li>
                                                                </ul>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

        `;
        return data;
    },
    createPagination: function (totalPages) {
        var paginationContainer = document.getElementById('ItemPagination');
        var paginationList = paginationContainer.querySelector('ul');
        paginationList.innerHTML = ''; // Clear existing pagination items
        if (totalPages <= 10) {
            ClsItemDetails.endPage = totalPages;
        }
        else if (ClsItemDetails.endPage === 0) {
            ClsItemDetails.endPage = 10;
        }
        if (!paginationContainer.querySelector('.first')) {
            var firstItem = document.createElement('li');
            firstItem.classList.add('first');
            var firstLink = document.createElement('a');
            firstLink.href = '#';
            firstLink.innerHTML = 'First';
            firstItem.appendChild(firstLink);
            paginationList.appendChild(firstItem);
            firstLink.addEventListener('click', function (event) {
                event.preventDefault();
                ClsItemDetails.currentPage = 1;
                ClsItemDetails.startPage = 1;
                ClsItemDetails.endPage = 10; // Assuming 10 pages per pagination
                ClsItemDetails.getData(1); // Execute another function here with updated current page
            });
        }

        // Create previous page link if not on first page
        if (ClsItemDetails.currentPage > 1) {
            var prevItem = document.createElement('li');
            prevItem.classList.add('prev');
            var prevLink = document.createElement('a');
            prevLink.href = '#';
            prevLink.innerHTML = '<i class="fa fa-arrow-left"></i>';
            prevItem.appendChild(prevLink);
            paginationList.appendChild(prevItem);
            prevLink.addEventListener('click', function (event) {
                event.preventDefault();
                if (ClsItemDetails.currentPage > ClsItemDetails.startPage) {
                    ClsItemDetails.currentPage--;
                } else if (ClsItemDetails.startPage === ClsItemDetails.startPage) {
                    ClsItemDetails.currentPage--;
                    ClsItemDetails.startPage--;
                    ClsItemDetails.endPage--;
                }
                paginationList.innerHTML = ''; // Clear existing pagination items // Recreate pagination with updated current page
                ClsItemDetails.getData(ClsItemDetails.currentPage); // Execute another function here with updated current page
            });
        }

        // Create page links
        for (var i = ClsItemDetails.startPage; i <= ClsItemDetails.endPage; i++) {
            var pageItem = document.createElement('li');
            var pageLink = document.createElement('a');
            pageLink.classList.add('LinksElemment');
            pageLink.href = '#';
            pageLink.innerHTML = i;
            pageItem.appendChild(pageLink);
            paginationList.appendChild(pageItem);


            if (ClsItemDetails.currentPage === 1 && i === 1) {
                pageLink.classList.add('current-page');
            }
            else if (ClsItemDetails.currentPage == i)
                pageLink.classList.add('current-page');

            pageLink.addEventListener('click', function (event) {
                event.preventDefault();
                myInput = event.target;
                // Apply focus to the clicked page link
                $('.LinksElemment').removeClass('current-page');
                $(myInput).addClass('current-page');
                var currentPage = parseInt(myInput.innerHTML);
                ClsItemDetails.currentPage = currentPage;
                // Execute another function here
                ClsItemDetails.getData(currentPage);
            });
        }

        // Create next page link if not on last page
        if (ClsItemDetails.currentPage < totalPages) {
            var nextItem = document.createElement('li');
            nextItem.classList.add('next');
            var nextLink = document.createElement('a');
            nextLink.href = '#';
            nextLink.innerHTML = '<i class="fa fa-arrow-right"></i>';
            nextItem.appendChild(nextLink);
            paginationList.appendChild(nextItem);
            nextLink.addEventListener('click', function (event) {
                event.preventDefault();
                if (ClsItemDetails.currentPage < ClsItemDetails.endPage) {
                    ClsItemDetails.currentPage++;
                } else if (ClsItemDetails.currentPage === ClsItemDetails.endPage) {
                    ClsItemDetails.currentPage++;
                    ClsItemDetails.startPage++;
                    ClsItemDetails.endPage++;
                }
                paginationList.innerHTML = ''; // Clear existing pagination items
                ClsItemDetails.getData(ClsItemDetails.currentPage); // Execute another function here with updated current page
            });
        }
        if (!paginationContainer.querySelector('.last')) {
            var lastItem = document.createElement('li');
            lastItem.classList.add('last');
            var lastLink = document.createElement('a');
            lastLink.href = '#';
            lastLink.innerHTML = 'Last';
            lastItem.appendChild(lastLink);
            paginationList.appendChild(lastItem);
            lastLink.addEventListener('click', function (event) {
                event.preventDefault();
                ClsItemDetails.currentPage = totalPages;
                if (ClsItemDetails.totalPage <= 10)
                    ClsItemDetails.startPage = 1
                else
                    ClsItemDetails.startPage = totalPages - 9;
                // Assuming 10 pages per pagination
                ClsItemDetails.endPage = totalPages;
                ClsItemDetails.getData(totalPages); // Execute another function here with updated current page
            });
        }
    },
    Init: function () {
        document.querySelectorAll('input[name="brand"]').forEach(checkbox => {
            checkbox.addEventListener("change", function () {
                document.querySelectorAll('input[name="brand"]').forEach(checkbox => {
                    if (checkbox.checked)
                        ClsItemDetails.categoryName = checkbox.nextElementSibling.textContent;

                    ClsItemDetails.getData(1);
                }); })
        });
        document.querySelectorAll('input[name="ram"]').forEach(checkbox => {
            checkbox.addEventListener("change", function () {
                document.querySelectorAll('input[name="ram"]').forEach(checkbox => {
                    if (checkbox.checked)
                        ClsItemDetails.ramSize = checkbox.nextElementSibling.textContent;
                    ClsItemDetails.getData(1);
                });
            })


        });
        document.querySelector('.chosen-select').addEventListener("change", function (e) {
            ClsItemDetails.pageSize = parseInt(e.target.value);
            ClsItemDetails.count = parseInt(e.target.value);
            ClsItemDetails.getData(1);
        })
    },
    initSearchTitleListener: function () {
        var timer; // Variable to store the timer

        document.getElementById('TitleInputSearch').addEventListener('input', function () {
            clearTimeout(timer); // Clear the previous timer
            timer = setTimeout(ClsItemDetails.Titlesearch, 1000); // Set a new timer to execute the search function after 2 seconds
        });
    },
    Titlesearch: function () {
        // Your search function code here
        var searchTerm = document.getElementById('TitleInputSearch').value;
        ClsItemDetails.title = searchTerm;
        ClsItemDetails.getData(1);
        // Call your search function here with the searchTerm value
    },
    initSearchPriceListener: function () {
        var timer; // Variable to store the timer

        document.getElementById('priceInputSearch').addEventListener('input', function () {
            clearTimeout(timer); // Clear the previous timer
            timer = setTimeout(ClsItemDetails.Pricesearch, 1000); // Set a new timer to execute the search function after 2 seconds
        });
    },
    Pricesearch: function () {
        // Your search function code here
        var searchTerm = document.getElementById('priceInputSearch').value;
        ClsItemDetails.maxPrice = searchTerm ?? null;
        ClsItemDetails.getData(1);
        // Call your search function here with the searchTerm value
    },
};

ClsItemDetails.Init();
ClsItemDetails.initSearchPriceListener();
ClsItemDetails.initSearchTitleListener();