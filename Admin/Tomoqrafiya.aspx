<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteUser.Master" AutoEventWireup="true" CodeFile="Tomoqrafiya.aspx.cs" Inherits="Category" %>

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
        function openModal1() {
            document.getElementById("btnyeni1").click();
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
            <button type="button" id="btnyeni1" class="btn btn-info btn-lg" style="visibility: hidden;" data-toggle="modal" data-target="#myModal1">Yeni</button>
        </div>
        <div class="col-lg-12 clearfix" style="height: 5px;"></div>
        <div class="col-lg-12">
            <table class="table table-hover table-responsive">
                <thead>
                    <tr style="font-weight: bold; border: 1px solid;">
                        <td class="tdler">№</td>
                        <td class="tdler">Adı AZ</td>
                        <td class="tdler">Adı EN</td>
                        <td class="tdler">Adı RU</td>
                        <td class="tdler">Növü</td>
                        <td class="tdler">Orqan</td>
                        <td class="tdler">Müayinə üsulu AZ</td>
                        <td class="tdler">Müayinə üsulu EN</td>
                        <td class="tdler">Müayinə üsulu RU</td>
                        <td class="tdler">Şəkil</td>
                        <td class="tdler">Dəyiş</td>
                        <td class="tdler">Sil</td>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td class="tdler"><%#Eval("SN") %></td>
                                <td class="tdler"><%#Eval("TomoqrafiyaNameAZ") %></td>
                                <td class="tdler"><%#Eval("TomoqrafiyaNameEN") %></td>
                                <td class="tdler"><%#Eval("TomoqrafiyaNameRU") %></td>
                                <td class="tdler"><%#Eval("MainName_AZ") %></td>
                                <td class="tdler"><%#Eval("OrganName_AZ") %></td>
                                <td class="tdler"><%#Eval("MuayineUsuluAZ") %></td>
                                <td class="tdler"><%#Eval("MuayineUsuluEN") %></td>
                                <td class="tdler"><%#Eval("MuayineUsuluRU") %></td>
                                <td class="tdler">
                                    <asp:LinkButton ID="LinkButton1" CssClass="btn btn-primary" CommandName="Slayd" CommandArgument='<%#Eval("TomoqrafiyaID") %>' runat="server">Slayd</asp:LinkButton></td>
                                <td class="tdler">
                                    <asp:LinkButton ID="LinkButton5" CssClass="btn btn-primary" CommandName="Deyish" CommandArgument='<%#Eval("TomoqrafiyaID") %>' runat="server">Dəyiş</asp:LinkButton></td>
                                <td class="tdler">
                                    <asp:LinkButton ID="LinkButton6" CssClass="btn btn-danger" CommandName="Sil" CommandArgument='<%#Eval("TomoqrafiyaID") %>' runat="server">Sil</asp:LinkButton></td>
                              
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
                        <h4 class="modal-title" style="font-family: 'Times New Roman'">Əsas kateqoriya</h4>
                    </div>
                    <div class="modal-body">
                         <div class="col-lg-12">
                            <div class="col-lg-4">
                                Adı AZ: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtTomoqrafiyaNameAZ" CssClass="form-control floatleft" runat="server" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="txtTomoqrafiyaNameAZ" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                Adı EN: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtTomoqrafiyaNameEN" CssClass="form-control floatleft" runat="server" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="txtTomoqrafiyaNameEN" ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                Adı RU: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtTomoqrafiyaNameRU" CssClass="form-control floatleft" runat="server" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="txtTomoqrafiyaNameRU" ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                Kateqoriya: *
                            </div>
                            <div class="col-lg-8">
                                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control floatleft"></asp:DropDownList>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="ddlCategory" ID="RequiredFieldValidator30" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                Orqan: *
                            </div>
                            <div class="col-lg-8">
                                <asp:DropDownList ID="ddlorgan" runat="server" CssClass="form-control floatleft" OnSelectedIndexChanged="ddlorgan_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="ddlorgan" ID="RequiredFieldValidator31" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                Növləri: *
                            </div>
                            <div class="col-lg-8">
                                <asp:DropDownList ID="ddlNov" runat="server" CssClass="form-control floatleft"></asp:DropDownList>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="ddlorgan" ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                       
                         <div class="col-lg-12">
                            <div class="col-lg-4">
                                Müayinə üsulu AZ: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtMuayineUsuluAZ" CssClass="form-control floatleft" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="txtMuayineUsuluAZ" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                Müayinə üsulu EN: *
                            </div>
                            <div class="col-lg-8">
                                 <asp:TextBox ID="txtMuayineUsuluEN" CssClass="form-control floatleft" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="txtMuayineUsuluEN" ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                Müayinə üsulu RU: *
                            </div>
                            <div class="col-lg-8">
                                 <asp:TextBox ID="txtMuayineUsuluRU" CssClass="form-control floatleft" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="requiredstyle" ValidationGroup="qrup1" ControlToValidate="txtMuayineUsuluRU" ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
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

         <div class="modal fade" id="myModal1" role="dialog" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog" style="font-family: 'Times New Roman'; font-weight: bold">

                <!-- Modal content-->
                
                         <div class="modal-content" style="width: 100%">
                              <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                    <div class="modal-header">
                        <button type="button" class="btn btn-danger" style="float: right;" data-dismiss="modal">X</button>
                        <h4 class="modal-title" style="font-family: 'Times New Roman'">Kateqoriyalar</h4>
                    </div>
                    <div class="modal-body">
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                Adı_AZ: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtSlideAZ" CssClass="form-control floatleft" runat="server"></asp:TextBox>
                             </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                Adı_EN: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtSlideEN" CssClass="form-control floatleft" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                Adı_RU: *
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="txtSlideRU" CssClass="form-control floatleft" runat="server"></asp:TextBox>                               
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                              Şəkil 
                            </div>
                            <div class="col-lg-8">
                                <asp:FileUpload ID="UPFotoAZ" runat="server" />
                                </div>
                            </div>
                         <div class="col-lg-12">
                            <div class="col-lg-4">
                              Şəkil 
                            </div>
                            <div class="col-lg-8">
                                <asp:FileUpload ID="UPFotoEN" runat="server" />
                                    </div>
                        </div>
                         <div class="col-lg-12">
                            <div class="col-lg-4">
                              Şəkil 
                            </div>
                            <div class="col-lg-8">
                                <asp:FileUpload ID="UPFotoRU" runat="server" />
                            </div>
                        </div>
                            <div class="col-lg-12">
                              <asp:Button ID="BtnFotoSave" class="btn btn-success" runat="server" Text="Yadda saxla" OnClick="BtnFotoSave_Click" />
                            </div>
                        
                        <div class="col-lg-12 clearfix" style="height: 25px;"></div>
                    </div>
                            
                    <div class="modal-footer">
                        <div class="col-lg-12">
                            <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater2_ItemCommand">
                                <ItemTemplate>                                    
                                    <div class="col-lg-6" style="border:1px solid black; padding:2px;">
                                        <div class="col-lg-4">
                                        <%#Eval("SlideName_AZ") %>
                                    </div>
                                        <div class="col-lg-4">
                                        <%#Eval("SlideName_EN") %>
                                    </div>
                                        <div class="col-lg-4">
                                        <%#Eval("SlideName_RU") %>
                                    </div>
                                        <div class="col-lg-4" style="border:1px solid black; padding:2px;">
                                            <img src='..\<%#Eval("SlideURL_AZ") %>' style="width:100%;"/>
                                        </div>    
                                        <div class="col-lg-4" style="border:1px solid black; padding:2px;">
                                            <img src='..\<%#Eval("SlideURL_EN") %>' style="width:100%;"/>
                                        </div> 
                                        <div class="col-lg-4" style="border:1px solid black; padding:2px;">
                                            <img src='..\<%#Eval("SlideURL_RU") %>' style="width:100%;"/>
                                        </div> 
                                        <div class="col-lg-12 text-left" style="padding:0px;">
                                            <div class="col-lg-8" style="padding:0px;">
                                                <asp:LinkButton ID="LinkButton6" CssClass="btn btn-info" CommandName="Deyish" CommandArgument='<%#Eval("SlideID") %>' runat="server">Dəyiş</asp:LinkButton>
                                            </div>
                                            <div class="col-lg-4" style="padding:0px;">
                                                <asp:LinkButton ID="LinkButton2" CssClass="btn btn-danger" CommandName="Sil" CommandArgument='<%#Eval("SlideID") %>' runat="server">Sil</asp:LinkButton>
                                            </div> 
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                             </ContentTemplate>
                </asp:UpdatePanel>
                </div>
                    
               

            </div>
        </div>
    </div>
</asp:Content>
