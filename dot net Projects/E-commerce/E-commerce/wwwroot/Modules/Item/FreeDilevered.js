var ClsFree = {

    reocmmendedIterate: 1,
    pageNumber: 8,
    getData: function () {
        // Fetch data for the given page number from the API

        var requestData = {
            pageNumber: ClsFree.pageNumber,
            count: 4,
        };
        $.ajax({
            url: 'https://localhost:7115/api/ApiItem/Post/',
            method: 'Post',
            contentType: 'application/json',
            data: JSON.stringify(requestData),
            dataType: 'json',
            success: function (data) {
                if (data.data.length === 0) {
                    ClsFree.renderData(data.data);
                    return;
                }

                ClsFree.renderData(data.data);


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
            htmlData += ClsFree.DrawItem(data[i]);
        }
        var d1 = document.getElementById(`delivery-${ClsFree.reocmmendedIterate}`);
        d1.innerHTML = htmlData;
        ClsFree.reocmmendedIterate++;
        ClsFree.pageNumber++;
    },
    DrawItem: function (item) {
        // Your existing DrawItem function remains unchanged
        // ...
        var data = `
       <div class="media">
                                    <a href="/Item/ItemDetails?id=${item.itemId}">
                                        <img class="img-fluid blur-up lazyload"
                                             src="/Uploads/Item/${item.imageName}" alt="">
                                    </a>
                                    <div class="media-body align-self-center">
                                        <div class="rating">
                                            <i class="fa fa-star"></i>
                                            <i class="fa fa-star"></i>
                                            <i class="fa fa-star"></i>
                                            <i class="fa fa-star"></i>
                                            <i class="fa fa-star"></i>
                                        </div>
                                        <a href="/Item/ItemDetails?id=${item.itemId}">
                                            <h6> ${item.itemName}</h6>
                                        </a>
                                        <h4>$${item.salesPrice} <del>$${item.salesPrice} </del></h4>
                                    </div>
                                </div>

        `;
        return data;
    },
};

