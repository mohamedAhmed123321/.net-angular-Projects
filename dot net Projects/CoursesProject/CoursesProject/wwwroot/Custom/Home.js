//var ClsSettings = {
//    GetAll: function () {
//        Helper.AjaxCallGet("https://localhost:7220/api/CoursesApi/GetAllWithData", {}, "json",
//            function (data) {

//                if (data.courseTypeId = !0)
//                {

//                }
//                else
//                {

//                }


//                let htmlExample = "";
//                for (var i = 0; i < data.data.length; i++)
//                {
                    
//                    console.log("mohamed between")
//                    htmlExample += ClsSettings.DrawItem(data.data[i]);

//                }
//                let DivContainer = document.getElementById('productboxContainer');
             
//                DivContainer.innerHTML = htmlExample;
//            }, function () { });
//    },
//    DrawItem: function (item) {
       
//            let data =`
//            <div class="product-box">
//                                        <div class="img-wrapper">
//                                            <div class="front">
//                                                <a asp-controller="Home" asp-action="CourseDetails" asp-route-id="@Colum.CourseId">
//                                                    <img src="~/Uploads/CoursesImage/${item.imageName}"
//                                                         style="width:300px" alt="">
//                                                </a>
//                                            </div>
                                    
//                                            <div class="cart-info cart-wrap">
//                                                <button data-toggle="modal" data-target="#addtocart"
//                                                        title="Add to cart">
//                                                    <i class="ti-shopping-cart"></i>
//                                                </button> <a href="javascript:void(0)" title="Add to Wishlist">
//                                                    <i class="ti-heart" aria-hidden="true"></i>
//                                                </a> <a href="#"
//                                                        data-toggle="modal" data-target="#quick-view" title="Quick View">
//                                                    <i class="ti-search" aria-hidden="true"></i>
//                                                </a> <a href="compare.html" title="Compare">
//                                                    <i class="ti-reload"
//                                                       aria-hidden="true"></i>
//                                                </a>
//                                            </div>
//                                        </div>
//                                        <div class="product-detail">
//                                            <div class="rating">
//                                                <i class="fa fa-star"></i> <i class="fa fa-star"></i> <i class="fa fa-star"></i> <i class="fa fa-star"></i> <i class="fa fa-star"></i>
//                                            </div>
//                                            <a href="product-page(no-sidebar).html">
//                                                <h6>${item.courseName}</h6>
//                                            </a>
//                                            @if (${item.price} == 0)
//                                            {
//                                                <h4>@general.lblFree</h4>
//                                            }
//                                            else
//                                            {
//                                                <h4>${item.price}</h4>
//                                            }
                                    
//                                            <ul class="color-variant">
//                                                <li class="bg-light0"></li>
//                                                <li class="bg-light1"></li>
//                                                <li class="bg-light2"></li>
//                                            </ul>
//                                        </div>
//                                    </div>`
//        return data;
//    }
//}

