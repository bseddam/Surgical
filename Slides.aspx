<%@ Page Title="" Language="C#" MasterPageFile="~/ChildMasterPage.master" AutoEventWireup="true" CodeFile="Slides.aspx.cs" Inherits="Slides" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section_wrap wrap_right ">

        <!-- Section Right Container-->
        <div class="section_wrap wrap_container ">


            <div class="sect_header clearfix ">
                <h2 class="sect_title ">
                    <asp:Literal ID="ltrlslide" runat="server"></asp:Literal></h2>
            </div>

            <div class="section_body clearfix">

                <%--   <div class="odds_row ">
                                        <div class="odds_row ">
                                            <div class="content_row ">
                                                <h2 class="title_first ">
                                                    <asp:Literal ID="ltrladi" runat="server"></asp:Literal> </h2>
                                            </div>
                                        </div>
                                        <div class="odds_row ">
                                            <div class="content_row row_inner ">
                                                <div class="content_inner clearfix">
                                                    <div class="conten_text ">
                                                    
                                                        <asp:Literal ID="ltrllecture" runat="server"></asp:Literal>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>--%>

                <div class="odds_row ">
                    <div class="odds_row ">
                        <div class="content_row ">
                            <h2 class="title_first ">
                                <asp:Literal ID="ltrlorgan" runat="server"></asp:Literal>
                            </h2>
                        </div>
                    </div>
                    <div class="odds_row ">
                        <div class="content_row row_inner ">
                            <div class="content_inner clearfix">
                                <div class="conten_text ">
                                    <asp:Literal ID="ltrlorqan" runat="server"></asp:Literal>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="odds_row ">
                    <div class="odds_row ">
                        <div class="content_row ">
                            <h2 class="title_first ">
                                <asp:Literal ID="lrtlkurs" runat="server"></asp:Literal>
                            </h2>
                        </div>
                    </div>
                    <div class="odds_row ">
                        <div class="content_row row_inner ">
                            <div class="content_inner clearfix">
                                <div class="conten_text ">
                                    <asp:Literal ID="ltrlcourse" runat="server"></asp:Literal>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="odds_row ">
                    <div class="odds_row ">
                        <div class="content_row row_inner">
                            <div class="content_inner clearfix">

                                <!-----------Gallery Start------------->
                                <div class="news_in_gallery">

                                    <div class="demo-gallery">
                                        <ul id="lightgallery" class="prosmotr_ul lightgallery">
                                            <li data-responsive="img/image1.png" data-src="img/image1.png" data-sub-html="">
                                                <a href="">
                                                    <img src="img/image1.png" alt="" class="product_gallery_images_upload img-responsive">
                                                    <div class="demo-gallery-poster">
                                                        <img src="img/icons/zoom.png">
                                                    </div>
                                                </a>
                                            </li>
                                            <li data-responsive="img/image2.png" data-src="img/image2.png" data-sub-html="">
                                                <a href="">
                                                    <img src="img/image2.png" alt="" class="product_gallery_images_upload img-responsive">
                                                    <div class="demo-gallery-poster">
                                                        <img src="img/icons/zoom.png">
                                                    </div>
                                                </a>
                                            </li>
                                            <li data-responsive="img/image1.png" data-src="img/image1.png" data-sub-html="">
                                                <a href="">
                                                    <img src="img/image1.png" alt="" class="product_gallery_images_upload img-responsive">
                                                    <div class="demo-gallery-poster">
                                                        <img src="img/icons/zoom.png">
                                                    </div>
                                                </a>
                                            </li>
                                            <li data-responsive="img/image2.png" data-src="img/image2.png" data-sub-html="">
                                                <a href="">
                                                    <img src="img/image2.png" alt="" class="product_gallery_images_upload img-responsive">
                                                    <div class="demo-gallery-poster">
                                                        <img src="img/icons/zoom.png">
                                                    </div>
                                                </a>
                                            </li>
                                            <li data-responsive="img/image1.png" data-src="img/image1.png" data-sub-html="">
                                                <a href="">
                                                    <img src="img/image1.png" alt="" class="product_gallery_images_upload img-responsive">
                                                    <div class="demo-gallery-poster">
                                                        <img src="img/icons/zoom.png">
                                                    </div>
                                                </a>
                                            </li>
                                            <li data-responsive="img/image2.png" data-src="img/image2.png" data-sub-html="">
                                                <a href="">
                                                    <img src="img/image2.png" alt="" class="product_gallery_images_upload img-responsive">
                                                    <div class="demo-gallery-poster">
                                                        <img src="img/icons/zoom.png">
                                                    </div>
                                                </a>
                                            </li>
                                            <li data-responsive="img/image1.png" data-src="img/image1.png" data-sub-html="">
                                                <a href="">
                                                    <img src="img/image1.png" alt="" class="product_gallery_images_upload img-responsive">
                                                    <div class="demo-gallery-poster">
                                                        <img src="img/icons/zoom.png">
                                                    </div>
                                                </a>
                                            </li>
                                            <li data-responsive="img/image2.png" data-src="img/image2.png" data-sub-html="">
                                                <a href="">
                                                    <img src="img/image2.png" alt="" class="product_gallery_images_upload img-responsive">
                                                    <div class="demo-gallery-poster">
                                                        <img src="img/icons/zoom.png">
                                                    </div>
                                                </a>
                                            </li>

                                        </ul>
                                    </div>

                                </div>
                                <!-----------Gallery End------------->

                            </div>
                        </div>
                </div>

            </div>

            <div class="odds_row ">
                <div class="odds_row ">
                    <div class="content_row row_inner ">
                        <h3 class="title_second ">
                            <asp:Literal ID="ltrlmuellif" runat="server"></asp:Literal>
                        </h3>
                        <div class="content_inner clearfix">
                            <div class="conten_text ">
                                <asp:Literal ID="ltrlmuellif1" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>



    </div>


    </div>
</asp:Content>

