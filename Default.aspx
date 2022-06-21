<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <!-- Section OUR MOVIES -->
    <%--<div class="section_wrap wrap_main_items">
        <div class="main_center clearfix">

            <div class="section_body">
                <div class="row">
                    <asp:Repeater ID="rpcategory" runat="server">
                        <ItemTemplate>


                            <div class="col odds_col clearfix">
                                <a href="/<%=Config.getLang(Page) %>/<%#Eval("Link").ToParseStr()%>" class="main_items">
                                    <div class="odds_row">
                                        <div class="item_title">
                                            <%#Eval("Name1").ToParseStr()%>
                                        </div>
                                    </div>
                                </a>
                            </div>


                        </ItemTemplate>
                    </asp:Repeater>


                </div>
            </div>
        </div>
    </div>--%>
    <!-- Section OUR MOVIES -->

</asp:Content>

