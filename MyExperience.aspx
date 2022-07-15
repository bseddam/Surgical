<%@ Page Title="" Language="C#" MasterPageFile="~/ChildMasterPage.master" AutoEventWireup="true" CodeFile="MyExperience.aspx.cs" Inherits="MyExperience" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section_wrap wrap_right ">

        <!-- Section Right Container-->
        <div class="section_wrap wrap_container ">


            <div class="sect_header clearfix ">
                <h2 class="sect_title ">
                    <asp:Literal ID="ltrlmyexperience" runat="server"></asp:Literal></h2>
            </div>

            <div class="section_body clearfix">


                <div class="odds_row ">
                    <div class="odds_row ">
                        <div class="content_row row_inner ">

                            <div class="content_inner clearfix">
                                <div class="conten_text ">
                                    <table class="classification">

                                        <asp:Literal ID="ltrlmuellif1" runat="server"></asp:Literal>


                                    </table>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="odds_row ">
                    <div class="odds_row ">
                        <div class="content_row row_inner ">
                            <h3 class="title_second ">
                                <asp:Literal ID="ltrladi" runat="server"></asp:Literal>
                            </h3>
                            <div class="content_inner clearfix">
                                <div class="conten_text ">
                                    <asp:Literal ID="ltrladitext" runat="server"></asp:Literal>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="odds_row ">
                    <div class="odds_row ">
                        <div class="content_row row_inner ">
                            <h3 class="title_second ">
                                <asp:Literal ID="ltrlmenimtecrubem" runat="server"></asp:Literal>
                            </h3>
                            <div class="content_inner clearfix">
                                <div class="conten_text ">
                                    <asp:Literal ID="ltrlmenimtecrubemtext" runat="server"></asp:Literal>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


            </div>



        </div>

    </div>

</asp:Content>

