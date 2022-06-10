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
                                <a href="#" class="main_items">
                                    <div class="opr_content">
                                        <div class="odds_row">
                                            <div class="catg_title" style="background-color: #db8436;">
                                                DƏRSLİK
                                            </div>
                                        </div>
                                        <div class="odds_row">
                                            <div class="catg_info">
                                                MƏDƏ ƏMƏLİYYATLARI
                                            </div>
                                        </div>
                                        <div class="odds_row">
                                            <div class="opr_title">
                                                MƏDƏ REZEKSİYASI
                                            </div>
                                        </div>
                                        <div class="odds_row">
                                            <div class="opr_info">
                                                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna eiusmod tempor incididunt ut labore et dolore magna
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

