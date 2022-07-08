<%@ Page Title="" Language="C#" MasterPageFile="~/ChildMasterPage.master" AutoEventWireup="true" CodeFile="Questions.aspx.cs" Inherits="Questions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section_wrap wrap_right ">

        <!-- Section Right Container-->
        <div class="section_wrap wrap_container ">


            <div class="sect_header clearfix ">
                <h2 class="sect_title ">
                    <asp:Literal ID="ltrlquestion" runat="server"></asp:Literal></h2>
            </div>

            <div class="section_body clearfix">

               
                        <div class="odds_row ">

                            <asp:Literal ID="ltrlcontainer" runat="server"></asp:Literal>

                        </div>



            </div>

        </div>


    </div>
</asp:Content>

