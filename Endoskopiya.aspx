<%@ Page Title="" Language="C#" MasterPageFile="~/ChildMasterPage.master" AutoEventWireup="true" CodeFile="Endoskopiya.aspx.cs" Inherits="Endoskopiya" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="section_wrap wrap_right ">

        <!-- Section Right Container-->
        <div class="section_wrap wrap_container ">


            <div class="sect_header clearfix ">
                <h2 class="sect_title ">
                    <asp:Literal ID="ltrlendoskopiya" runat="server"></asp:Literal></h2>
            </div>

            <div class="section_body clearfix">

                                    <div class="odds_row ">
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
                                                    
                                                        <asp:Literal ID="ltrlendoscopiyaname" runat="server"></asp:Literal>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="odds_row ">
                                        <div class="odds_row ">
                                            <div class="content_row ">
                                                <h2 class="title_first ">
                                                    <asp:Literal ID="ltrlorgan" runat="server"></asp:Literal> </h2>
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
                                                <h2 class="title_first "><asp:Literal ID="lrtlmuayineusulu" runat="server"></asp:Literal> </h2>
                                            </div>
                                        </div>
                                        <div class="odds_row ">
                                            <div class="content_row row_inner ">
                                                <div class="content_inner clearfix">
                                                    <div class="conten_text ">
                                                         <asp:Literal ID="ltrlmuayine" runat="server"></asp:Literal> 
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="odds_row ">
                                        <div class="odds_row ">
                                            <div class="content_row ">
                                                <h2 class="title_first "><asp:Literal ID="ltrlvideo" runat="server"></asp:Literal> </h2>
                                            </div>
                                        </div>
                                        <div class="odds_row ">
                                            <div class="content_row row_inner ">
                                                <div class="content_inner clearfix">
                                                    <div class="conten_text ">
                                                        <asp:Literal ID="ltrlvideo1" runat="server"></asp:Literal>
                                                        </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--<div class="odds_row ">
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
                                    </div>--%>

                                </div>

        

        </div>


    </div>

</asp:Content>

