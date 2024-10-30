

var Clsrecommend = {

    reocmmendedIterate: 1,
    pageNumber:4,
    getData: function () {
        // Fetch data for the given page number from the API
        var requestData = {
            pageNumber: Clsrecommend.pageNumber,
            count: 6,
        };
        $.ajax({
            url: 'https://localhost:7115/api/ApiItem/Post/',
            method: 'Post',
            contentType: 'application/json',
            data: JSON.stringify(requestData),
            dataType: 'json',
            success: function (data) {
                if (data.data.length === 0) {
                    Clsrecommend.renderData(data.data);
                    return;
                }

                Clsrecommend.renderData(data.data);


            },
            error: function () {
                // Handle error
                console.log("error")
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
            htmlData += Clsrecommend.DrawItem(data[i]);
        }
        var d1 = document.getElementById(`Recommended-${Clsrecommend.reocmmendedIterate}`);
        d1.innerHTML = htmlData;
        Clsrecommend.reocmmendedIterate++;
        Clsrecommend.pageNumber++;
    },
    DrawItem: function (item) {
        // Your existing DrawItem function remains unchanged
        // ...
        var data = `
  <div class="product-box">
                                        <div class="img-wrapper">
                                            <div class="front">
                                                <a href="/Item/ItemDetails?id=${item.itemId}">
                                                    <img src="/Uploads/Item/${item.imageName}"
                                                         class="img-fluid blur-up lazyload bg-img" alt="">
                                                </a>
                                            </div>
                                            <div class="cart-info cart-wrap">
                                                <a href="/Item/ItemDetails?id=${item.itemId}">
                                                    <i class="ti-heart" aria-hidden="true"></i>
                                                </a>
                                                <a href="/Item/ItemDetails?id=${item.itemId}">
                                                    <i class="ti-search"
                                                       aria-hidden="true"></i>
                                                </a>
                                                <a href="compare.html" title="Compare" tabindex="0">
                                                    <i class="ti-reload"
                                                       aria-hidden="true"></i>
                                                </a>
                                            </div>
                                            <div class="add-button" data-toggle="modal" data-target="#addtocart">
                                                                       <a  href="/Order/AddToCart?id=${item.itemId}">
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
                                                <h6>${item.itemName}</h6>
                                            </a>
                                            <h4>$${item.salesPrice}</h4>
                                        </div>
                                    </div>

        `;
        return data;
    },
};

