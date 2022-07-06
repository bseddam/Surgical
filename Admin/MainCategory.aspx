<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteUser.Master" AutoEventWireup="true" CodeFile="MainCategory.aspx.cs" Inherits="Kateqoriya" %>

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
                        <td class="tdler">Adı_AZ</td>
                        <td class="tdler">Adı_EN</td>
                        <td class="tdler">Adı_RU</td>
                        <td class="tdler">Məlumat_AZ</td>
                        <td class="tdler">Məlumat_EN</td>
                        <td class="tdler">Məlumat_RU</td>
                        <td class="tdler">Patologiya_AZ</td>
                        <td class="tdler">Patologiya_EN</td>
                        <td class="tdler">Patologiya_RU</td>
                        <td class="tdler">Səriştə_AZ</td>
                        <td class="tdler">Səriştə_EN</td>
                        <td class="tdler">Səriştə_RU</td>
                        <td class="tdler">Səviyyə_AZ</td>
                        <td class="tdler">Səviyyə_EN</td>
                        <td class="tdler">Səviyyə_RU</td>
                        <td class="tdler">Səviyyə_tələbə_AZ</td>
                        <td class="tdler">Səviyyə_tələbə_EN</td>
                        <td class="tdler">Səviyyə_tələbə_RU</td>
                        <td class="tdler">Səviyyə_rezident_AZ</td>
                        <td class="tdler">Səviyyə_rezident_EN</td>
                        <td class="tdler">Səviyyə_rezident_RU</td>
                        <td class="tdler">Kurs</td>
                        <td class="tdler">Saat</td>
                        <td class="tdler">XBT kodu</td>
                        <td class="tdler">Açar sözlər_AZ</td>
                        <td class="tdler">Açar sözlər_EN</td>
                        <td class="tdler">Açar sözlər_RU</td>
                        <td class="tdler">DOİ</td>
                        <td class="tdler">URL</td>
                        <td class="tdler">Sıra nömrəsi</td>
                        <td class="tdler">Dəyiş</td>
                        <td class="tdler">Sil</td>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td class="tdler"><%#Eval("SN") %></td>
                                <td class="tdler"><%#Eval("MainName_AZ") %></td>
                                <td class="tdler"><%#Eval("MainName_EN") %></td>
                                <td class="tdler"><%#Eval("MainName_RU") %></td>
                                <td class="tdler"><%#Eval("Information_AZ") %></td>
                                <td class="tdler"><%#Eval("Information_EN") %></td>
                                <td class="tdler"><%#Eval("Information_RU") %></td>
                                <td class="tdler"><%#Eval("Patalogy_AZ") %></td>
                                <td class="tdler"><%#Eval("Patalogy_EN") %></td>
                                <td class="tdler"><%#Eval("Patalogy_RU") %></td>
                                <td class="tdler"><%#Eval("Serishte_AZ") %></td>
                                <td class="tdler"><%#Eval("Serishte_EN") %></td>
                                <td class="tdler"><%#Eval("Serishte_RU") %></td>
                                <td class="tdler"><%#Eval("Seviyye_AZ") %></td>
                                <td class="tdler"><%#Eval("Seviyye_EN") %></td>
                                <td class="tdler"><%#Eval("Seviyye_RU") %></td>
                                <td class="tdler"><%#Eval("Seviyye_telebe_AZ") %></td>
                                <td class="tdler"><%#Eval("Seviyye_telebe_EN") %></td>
                                <td class="tdler"><%#Eval("Seviyye_telebe_RU") %></td>
                                <td class="tdler"><%#Eval("Seviyye_rezident_AZ") %></td>
                                <td class="tdler"><%#Eval("Seviyye_rezident_EN") %></td>
                                <td class="tdler"><%#Eval("Seviyye_rezident_RU") %></td>
                                <td class="tdler"><%#Eval("Kurs") %></td>
                                <td class="tdler"><%#Eval("Saat") %></td>
                                <td class="tdler"><%#Eval("XBT_Kodu") %></td>
                                <td class="tdler"><%#Eval("Acar_sozler_AZ") %></td>
                                <td class="tdler"><%#Eval("Acar_sozler_EN") %></td>
                                <td class="tdler"><%#Eval("Acar_sozler_RU") %></td>
                                <td class="tdler"><%#Eval("DOI") %></td>
                                <td class="tdler"><%#Eval("URL") %></td>
                                <td class="tdler"><%#Eval("SortBy") %></td>
                                <td class="tdler">
                                    <asp:LinkButton ID="LinkButton5" CssClass="btn btn-primary" CommandName="Deyish" CommandArgument='<%#Eval("MainID") %>' runat="server">Dəyiş</asp:LinkButton></td>
                                <td class="tdler">
                                    <asp:LinkButton ID="LinkButton6" CssClass="btn btn-danger" CommandName="Sil" CommandArgument='<%#Eval("MainID") %>' runat="server">Sil</asp:LinkButton></td>
                              
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
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="btn btn-danger" style="float: right;" data-dismiss="modal">X</button>
                        <h4 class="modal-title" style="font-family: 'Times New Roman'">Mövzular</h4>
                    </div>
                    <div class="modal-body">
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                Adı_AZ: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtMainNameAZ" CssClass="form-control floatleft" runat="server" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="txtMainNameAZ" ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                Adı_EN: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtMainNameEN" CssClass="form-control floatleft" runat="server" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="txtMainNameEN" ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                Adı_RU: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtMainNameRU" CssClass="form-control floatleft" runat="server" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="txtMainNameRU" ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                Təsnifat: *
                            </div>
                            <div class="col-lg-8">
                                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control floatleft"></asp:DropDownList>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="ddlCategory" ID="RequiredFieldValidator30" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                Orqan: *
                            </div>
                            <div class="col-lg-8">
                                <asp:DropDownList ID="ddlorgan" runat="server" CssClass="form-control floatleft"></asp:DropDownList>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="ddlorgan" ID="RequiredFieldValidator31" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                         <div class="col-lg-12">
                            <div class="col-lg-4">
                                Məlumat_AZ: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtInformationAZ" CssClass="form-control floatleft" runat="server" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="txtInformationAZ" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                Məlumat_EN: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtInformationEN" CssClass="form-control floatleft" runat="server" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="txtInformationEN" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                Məlumat_RU: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtInformationRU" CssClass="form-control floatleft" runat="server" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="txtInformationRU" ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                         <div class="col-lg-12">
                            <div class="col-lg-4">
                                Patologiya_AZ: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtPatalogyAZ" CssClass="form-control floatleft" runat="server" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="txtPatalogyAZ" ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                Patologiya_EN: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtPatalogyEN" CssClass="form-control floatleft" runat="server" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="txtPatalogyEN" ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                Patologiya_RU: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtPatalogyRU" CssClass="form-control floatleft" runat="server" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="txtPatalogyRU" ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                         <div class="col-lg-12">
                            <div class="col-lg-4">
                                Səriştə_AZ: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtSerishteAZ" CssClass="form-control floatleft" runat="server" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="txtSerishteAZ" ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                Səriştə_EN: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtSerishteEN" CssClass="form-control floatleft" runat="server" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="txtSerishteEN" ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                Səriştə_RU: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtSerishteRU" CssClass="form-control floatleft" runat="server" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="txtSerishteRU" ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                         <div class="col-lg-12">
                            <div class="col-lg-4">
                                Səviyyə_AZ: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtSeviyyeAZ" CssClass="form-control floatleft" runat="server" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="txtSeviyyeAZ" ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                Səviyyə_EN: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtSeviyyeEN" CssClass="form-control floatleft" runat="server" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="txtSeviyyeEN" ID="RequiredFieldValidator14" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                Səviyyə_RU: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtSeviyyeRU" CssClass="form-control floatleft" runat="server" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="txtSeviyyeRU" ID="RequiredFieldValidator15" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                         <div class="col-lg-12">
                            <div class="col-lg-4">
                                Səviyyə tələbə_AZ: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="SeviyyeTelebeAZ" CssClass="form-control floatleft" runat="server" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="SeviyyeTelebeAZ" ID="RequiredFieldValidator16" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                Səviyyə tələbə_EN: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="SeviyyeTelebeEN" CssClass="form-control floatleft" runat="server" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="SeviyyeTelebeEN" ID="RequiredFieldValidator17" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                Səviyyə tələbə_RU: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="SeviyyeTelebeRU" CssClass="form-control floatleft" runat="server" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="SeviyyeTelebeRU" ID="RequiredFieldValidator18" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                         <div class="col-lg-12">
                            <div class="col-lg-4">
                                Səviyyə rezident_AZ: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="SeviyyeRezidentAZ" CssClass="form-control floatleft" runat="server" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="SeviyyeRezidentAZ" ID="RequiredFieldValidator19" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                Səviyyə rezident_EN: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="SeviyyeRezidentEN" CssClass="form-control floatleft" runat="server" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="SeviyyeRezidentEN" ID="RequiredFieldValidator20" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                Səviyyə rezident_RU: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="SeviyyeRezidentRU" CssClass="form-control floatleft" runat="server" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="SeviyyeRezidentRU" ID="RequiredFieldValidator21" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                         <div class="col-lg-12">
                            <div class="col-lg-4">
                                Kurs: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtKurs" CssClass="form-control floatleft" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="txtKurs" ID="RequiredFieldValidator22" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                Saat: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtSaat" CssClass="form-control floatleft" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="txtSaat" ID="RequiredFieldValidator23" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                XBT Kodu: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtXBTKodu" CssClass="form-control floatleft" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="txtXBTKodu" ID="RequiredFieldValidator24" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                         <div class="col-lg-12">
                            <div class="col-lg-4">
                                Açar sözlər_AZ: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="AcarSozlerAZ" CssClass="form-control floatleft" runat="server" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="AcarSozlerAZ" ID="RequiredFieldValidator25" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                Açar sözlər_EN: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="AcarSozlerEN" CssClass="form-control floatleft" runat="server" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="AcarSozlerEN" ID="RequiredFieldValidator26" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                Açar sözlər_RU: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="AcarSozlerRU" CssClass="form-control floatleft" runat="server" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="AcarSozlerRU" ID="RequiredFieldValidator27" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                         <div class="col-lg-12">
                            <div class="col-lg-4">
                                DOİ: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtDOI" CssClass="form-control floatleft" runat="server" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="txtDOI" ID="RequiredFieldValidator28" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                URL: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtURL" CssClass="form-control floatleft" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="txtURL" ID="RequiredFieldValidator29" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                Sıradakı yeri: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtSortBy" CssClass="form-control floatleft" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="txtSortBy" ID="RequiredFieldValidator32" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
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
