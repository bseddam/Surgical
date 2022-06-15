<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="all_operations.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section_wrap wrap_operations">
        <div class="main_center clearfix">
            <div class="section_body">
                <div class="row">

                    <asp:Repeater ID="rptalloperations" runat="server">
                        <ItemTemplate>
                            <div class="col odds_col clearfix">
                                <a href="<%#Methods.GetURL(Config.getLang(Page),"leadership",Eval("OrganID").ToParseInt(),
    Eval("CategoryID").ToParseInt(),Eval("MainID").ToParseInt(), Eval("HeaderID").ToParseInt())%>" class="main_items">
                                    <div class="opr_content">
                                        <div class="odds_row">
                                            <div class="catg_title" style="background-color: <%#Eval("headercolor").ToParseStr()%>;">
                                                <%#Eval("HeaderName").ToParseStr()%>
                                            </div>
                                        </div>
                                        <div class="odds_row">
                                            <div class="catg_info">
                                                <%#Eval("orqcat").ToParseStr()%>
                                            </div>
                                        </div>
                                        <div class="odds_row">
                                            <div class="opr_title">
                                                   <%#Eval("MainName").ToParseStr()%>
                                            </div>
                                        </div>
                                        <div class="odds_row">
                                            <div class="opr_info">
                                            <%#Eval("Seviyye").ToParseStr()%>    
                                            </div>
                                        </div>
                                    </div>
                                </a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                </div>
            </div>
            <div class="sect_footer clearfix">
                <div class="more clearfix">
                    <a href="javascript:void(0)" class="more_link">
                        <span class="more_name" id="more_btn">Daha çox</span>
                    </a>
                </div>
            </div>

        </div>
    </div>
</asp:Content>

