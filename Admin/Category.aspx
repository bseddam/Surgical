<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteUser.Master" AutoEventWireup="true" CodeFile="Category.aspx.cs" Inherits="Category" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .tdler {
            border: 1px solid;
            max-width: 120px;
            word-wrap: break-word;
        }

        table thead tr td {
            text-align: center;
        }

        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=40);
            opacity: 0.4;
        }

        .modalPopup {
            background-color: #FFFFFF;
            width: 300px;
            border: 3px solid #0DA9D0;
        }

            .modalPopup .header {
                background-color: #2FBDF1;
                height: 30px;
                color: White;
                line-height: 30px;
                text-align: center;
                font-weight: bold;
            }

            .modalPopup .body {
                min-height: 50px;
                line-height: 30px;
                text-align: center;
                font-weight: bold;
            }

            .modalPopup .footer {
                padding: 3px;
            }

            .modalPopup .yes, .modalPopup .no {
                height: 23px;
                color: White;
                line-height: 23px;
                text-align: center;
                font-weight: bold;
                cursor: pointer;
            }

            .modalPopup .yes {
                background-color: #2FBDF1;
                border: 1px solid #0DA9D0;
            }

            .modalPopup .no {
                background-color: #9F9F9F;
                border: 1px solid #5C5C5C;
            }
    </style>
    <link href="../UsersStyle/bootstrap.min.css" rel="stylesheet" />
    <script src="../UsersStyle/jquery.min.js"></script>
    <script src="../UsersStyle/bootstrap.min.js"></script>
    <script type="text/javascript">
        function cleartext() {
            document.getElementById("dateVerildiyiTarix").innerText = "";
        }
        function openModal() {
            document.getElementById("btnyeni").click();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <style>
        .requiredstyle {
            font-size: 18px;
        }

        .form-control {
            width: 95%;
        }

        .floatleft {
            float: left;
        }
    </style>
    <div class="col-lg-12" style="font-family: 'Times New Roman';">
        <div class="col-lg-12">
            <asp:Button ID="Button3" runat="server" class="btn btn-info btn-lg" Text="Yeni" OnClick="Button3_Click" />
            <button type="button" id="btnyeni" class="btn btn-info btn-lg" style="visibility: hidden;" data-toggle="modal" data-target="#myModal">Yeni</button>
        </div>
        <div class="col-lg-12 clearfix" style="height: 5px;"></div>
        <div class="col-lg-12">
            <table class="table table-hover table-responsive">
                <thead>
                    <tr style="font-weight: bold; border: 1px solid;">
                        <td class="tdler">№</td>
                        <td class="tdler">Kateqoriya_AZ</td>
                        <td class="tdler">Kateqoriya_EN</td>
                        <td class="tdler">Kateqoriya_RU</td>
                        <td class="tdler">Sıradakı yeri</td>
                        <td class="tdler">Dəyiş</td>
                        <td class="tdler">Sil</td>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td class="tdler"><%#Eval("SN") %></td>
                                <td class="tdler"><%#Eval("CategoryName_AZ") %></td>
                                <td class="tdler"><%#Eval("CategoryName_EN") %></td>
                                <td class="tdler"><%#Eval("CategoryName_RU") %></td>
                                <td class="tdler"><%#Eval("SortBy") %></td>
                                <td class="tdler" align="center">
                                    <asp:LinkButton ID="LinkButton5" CssClass="btn btn-primary" CommandName="Deyish" CommandArgument='<%#Eval("CategoryID") %>' runat="server">Dəyiş</asp:LinkButton></td>
                                <td class="tdler" align="center">
                                    <asp:LinkButton ID="LinkButton6" CssClass="btn btn-danger" CommandName="Sil" CommandArgument='<%#Eval("CategoryID") %>' runat="server">Sil</asp:LinkButton></td>
                              
                                <ajaxToolkit:ConfirmButtonExtender ID="cbe" runat="server" DisplayModalPopupID="mpe" TargetControlID="LinkButton6" />
                                <ajaxToolkit:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlPopup" TargetControlID="LinkButton6"
                                    OkControlID="btnYes" CancelControlID="btnNo" BackgroundCssClass="modalBackground">
                                </ajaxToolkit:ModalPopupExtender>
                                <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" Style="display: none;">
                                    <div class="header">
                                        Bildiriş
                                    </div>
                                    <div class="body">
                                        Silməyə əminsinizmi?
                                    </div>
                                    <div class="footer" align="right">
                                        <asp:Button ID="btnYes" runat="server" Text="Bəli" CssClass="yes" />
                                        <asp:Button ID="btnNo" runat="server" Text="Xeyr" CssClass="no" />
                                    </div>
                                </asp:Panel>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        <div class="modal fade" id="myModal" role="dialog" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog" style="font-family: 'Times New Roman'; font-weight: bold">

                <!-- Modal content-->
                <div class="modal-content" style="width: 100%">
                    <div class="modal-header">
                        <button type="button" class="btn btn-danger" style="float: right;" data-dismiss="modal">X</button>
                        <h4 class="modal-title" style="font-family: 'Times New Roman'">Kateqoriyalar</h4>
                    </div>
                    <div class="modal-body">
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                Kateqoriya_AZ: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtKateqoriyaAZ" CssClass="form-control floatleft" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="txtKateqoriyaAZ" ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                Kateqoriya_EN: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtKateqoriyaEN" CssClass="form-control floatleft" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="txtKateqoriyaEN" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                Kateqoriya_RU: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtKateqoriyaRU" CssClass="form-control floatleft" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="txtKateqoriyaRU" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                Sıradakı yeri: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtSortBy" CssClass="form-control floatleft" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="txtSortBy" ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-12 clearfix" style="height: 25px;"></div>
                    </div>
                    <div class="modal-footer">
                        <div class="col-lg-12">
                            <div class="col-lg-7">
                            </div>
                            <div class="col-lg-5" style="text-align: left;">
                                <asp:Button ID="Button1" ValidationGroup="qrup1" class="btn btn-success" runat="server" Text="Yadda saxla" OnClick="Button1_Click" />
                            </div>
                        </div>
                        <div class="col-lg-12" style="text-align: left;">
                            <hr />
                            <asp:Label ID="lblfooternote" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>

            </div>
        </div>

    </div>
</asp:Content>
