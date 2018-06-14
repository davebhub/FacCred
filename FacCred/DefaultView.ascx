<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DefaultView.ascx.cs" Inherits="FacCred.DefaultView"  %>
<%@ Register Assembly="Jenzabar.Common" Namespace="Jenzabar.Common.Web.UI.Controls" TagPrefix="common"  %>
<%@Import namespace="Jenzabar.Portal.Framework"%>
<%@ Register TagName="MainMenu" TagPrefix="mom"  src="Screens/MainMenu.ascx"   %>


<%--background-color:#036534  green;
background-color:#265B8C  blue  ;--%>


<style type="text/css" >
.globalizedbutton
{
    width:105px;
    height: 30px;
    background-color: #036534;
    line-height: 30px;
    padding-bottom: 2px;
    vertical-align: middle;
    font-family: "Lucida Grande", Geneva, Verdana, Arial, Helvetica, sans-serif;
    font-size: 16px;
    text-transform: none;
    border:1px solid transparent;
    color:white;
}
.globalizedbutton:hover
{
    background-color:gainsboro;
    color:#265B8C;
}
.buttonBar{
    background-color:#036534;
}
.loader {
    position: fixed;
    left: 0px;
    top: 0px;
    width: 100%;
    height: 100%;
    z-index: 9999;
    background: url("UI/Common/Images/PortletImages/Lightbox/loading.gif") 50% 50% no-repeat rgb(249,249,249);
}
</style>
<%--    background-color:#265B8C;--%>
<div class="loader"></div>

<div>
    <mom:MainMenu id="mainMenu" runat="server"></mom:MainMenu>
</div>


<asp:Panel ScrollBars="Vertical" Height="500px" runat="server">

<div>

<br />
<asp:Label ID="Label1" runat="server" Font-Size="X-Large" Text="Label">Faculty Credentials</asp:Label>
<br /><br />


    <table>
        <tr >
            <td >
                <asp:Image ID="Image1" runat="server"  ImageUrl="~/UI/Common/Images/mc_campus_aerial.jpg"   />
                <br /><br /><br />
                <p style="width:400px">
                    <strong>Midland College</strong> is a comprehensive community college that is dedicated to excellence, 
                    has a commitment to learning, and promotes a lifelong quest for knowledge. 
                    The institution supports individual and economic development in its service area and beyond by offering certificates, 
                    associate and baccalaureate degrees, workforce and continuing education opportunities, 
                    and comprehensive student support services. Midland College also provides a variety of community services, 
                    cultural and educational enrichment opportunities to the West Texas region
                </p>

            </td>
            <td style="width:50px"></td>
            <td>
            <p style="font-size:medium">        
                <strong>
                -Guidelines-
                </strong>      
            </p>
            <p style="width:500px">
                The insitution employs competent faculty members qualified to accomplish the mission and goals of the institution. 
                When determining acceptable qualifications of its faculty, an institution gives primary consideration 
                to the highest earned degree in the discipline. 
            </p>
            <p style="width:500px">
                The institution also considers competence, effectiveness, and capacity, incluing, as appropriate, undergraduate and 
                graduate degrees, related work experiences in the field, professional licensure and certifications, honors and awards,
                continuous documented excellence in teaching, or other demonstrated competencies and achievements that contribute to 
                effective teaching and student learning outcomes. 
            </p>
            <p style="width:500px">
                <strong>
                For all cases, the institution is responsible for justifying and documenting the qualifications of its faculty.
                </strong>
            </p>


            </td>
        </tr>
    </table>

</div>
   
</asp:Panel>


<script type="text/javascript">
    $(window).load(function () {
        $(".loader").fadeOut("slow");
    })

     $(document).ready(function () {
        
     });
</script>

