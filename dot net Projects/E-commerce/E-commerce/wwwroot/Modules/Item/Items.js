

var ClsItem = {
    pageSize: 12,
    totalPage: 3,
    currentPage: 1,
    startPage: 1,
    endPage: 0,
    emptyStringToGuid: function () {
        // Generate a new GUID in the format '00000000-0000-0000-0000-000000000000'
        return '00000000-0000-0000-0000-000000000000';
    },
    getData: function (pageNumber) {
        var loader = document.getElementById('loader-background');
        // Fetch data for the given page number from the API

        var requestData = {
            pageNumber: pageNumber,
            count: ClsItem.pageSize,
        };
        $.ajax({
            url: 'https://localhost:7115/api/ApiItem/Post/',
            method: 'Post',
            contentType: 'application/json',
            data: JSON.stringify(requestData),
            dataType: 'json',
            success: function (data) {
                if (data.data.length === 0) {
                    ClsItem.renderData(data.data);
                    loader.style.display = 'none';
                    return;
                }

                ClsItem.totalPage = data.data[0].totalPages;
                ClsItem.renderData(data.data);
                ClsItem.createPagination(parseInt(ClsItem.totalPage));
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
            htmlData += ClsItem.DrawItem(data[i]);
        }

        var d1 = document.getElementById('ItemArea');
        d1.innerHTML = htmlData;
    },
    DrawItem: function (item) {
        // Your existing DrawItem function remains unchanged
        // ...
        var data = `
                <div class="product-box col-xl-2 col-lg-3 col-sm-4 col-6">
                    <div class="img-wrapper">
                        <div class="lable-block"><span class="lable4">on sale</span></div>
                        <div class="front">
                            <a href="/Item/ItemDetails?id=${item.itemId}">
                                <img src="/Uploads/Item/${item.imageName}"
                                     class="img-fluid blur-up lazyload bg-img" alt="there is no image">
                            </a>
                        </div>
                        <div class="cart-info cart-wrap">
                            <a href="javascript:void(0)" title="Add to Wishlist" tabindex="0">
                                <i class="ti-heart"
                                   aria-hidden="true"></i>
                            </a>
                            <a href="#" data-toggle="modal" data-target="#quick-view" title="Quick View" tabindex="0">
                                <i class="ti-search" aria-hidden="true"></i>
                            </a>
                            <a href="compare.html" title="Compare" tabindex="0">
                                <i class="ti-reload"
                                   aria-hidden="true"></i>
                            </a>
                        </div>
                        <div class="add-button" data-toggle="modal" data-target="#addtocart">
                              <a  href="/Order/AddToCart?itemId=${item.itemId}">
                                   add to
                                     cart
                                  </a>
                        </div>
                    </div>
                    <div class="product-detail">
                        <div class="rating">
                            <i class="fa fa-star"></i> <i class="fa fa-star"></i> <i class="fa fa-star"></i> <i class="fa fa-star"></i> <i class="fa fa-star"></i>
                        </div>
                        <a href="product-page(no-sidebar).html">
                            <h6>${item.itemName} </h6>
                        </a>
                        <h4>${item.salesPrice}</h4>
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
            ClsItem.endPage = totalPages;
        }
        else if (ClsItem.endPage === 0) {
            ClsItem.endPage = 10;
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
                ClsItem.currentPage = 1;
                ClsItem.startPage = 1;
                ClsItem.endPage = 10; // Assuming 10 pages per pagination
                ClsItem.getData(1); // Execute another function here with updated current page
            });
        }

        // Create previous page link if not on first page
        if (ClsItem.currentPage > 1) {
            var prevItem = document.createElement('li');
            prevItem.classList.add('prev');
            var prevLink = document.createElement('a');
            prevLink.href = '#';
            prevLink.innerHTML = '<i class="fa fa-arrow-left"></i>';
            prevItem.appendChild(prevLink);
            paginationList.appendChild(prevItem);
            prevLink.addEventListener('click', function (event) {
                event.preventDefault();
                if (ClsItem.currentPage > ClsItem.startPage) {
                    ClsItem.currentPage--;
                } else if (ClsItem.startPage === ClsItem.startPage) {
                    ClsItem.currentPage--;
                    ClsItem.startPage--;
                    ClsItem.endPage--;
                }
                paginationList.innerHTML = ''; // Clear existing pagination items // Recreate pagination with updated current page
                ClsItem.getData(ClsItem.currentPage); // Execute another function here with updated current page
            });
        }

        // Create page links
        for (var i = ClsItem.startPage; i <= ClsItem.endPage; i++) {
            var pageItem = document.createElement('li');
            var pageLink = document.createElement('a');
            pageLink.classList.add('LinksElemment');
            pageLink.href = '#';
            pageLink.innerHTML = i;
            pageItem.appendChild(pageLink);
            paginationList.appendChild(pageItem);


            if (ClsItem.currentPage === 1 && i === 1) {
                pageLink.classList.add('current-page');
            }
            else if (ClsItem.currentPage == i)
                pageLink.classList.add('current-page');

            pageLink.addEventListener('click', function (event) {
                event.preventDefault();
                myInput = event.target;
                // Apply focus to the clicked page link
                $('.LinksElemment').removeClass('current-page');
                $(myInput).addClass('current-page');
                var currentPage = parseInt(myInput.innerHTML);
                ClsItem.currentPage = currentPage;
                // Execute another function here
                ClsItem.getData(currentPage);
            });
        }

        // Create next page link if not on last page
        if (ClsItem.currentPage < totalPages) {
            var nextItem = document.createElement('li');
            nextItem.classList.add('next');
            var nextLink = document.createElement('a');
            nextLink.href = '#';
            nextLink.innerHTML = '<i class="fa fa-arrow-right"></i>';
            nextItem.appendChild(nextLink);
            paginationList.appendChild(nextItem);
            nextLink.addEventListener('click', function (event) {
                event.preventDefault();
                if (ClsItem.currentPage < ClsItem.endPage) {
                    ClsItem.currentPage++;
                } else if (ClsItem.currentPage === ClsItem.endPage) {
                    ClsItem.currentPage++;
                    ClsItem.startPage++;
                    ClsItem.endPage++;
                }
                paginationList.innerHTML = ''; // Clear existing pagination items
                ClsItem.getData(ClsItem.currentPage); // Execute another function here with updated current page
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
                ClsItem.currentPage = totalPages;
                if (ClsItem.totalPage <= 10)
                    ClsItem.startPage = 1
                else
                    ClsItem.startPage = totalPages - 9;
                // Assuming 10 pages per pagination
                ClsItem.endPage = totalPages;
                ClsItem.getData(totalPages); // Execute another function here with updated current page
            });
        }
    }
};

