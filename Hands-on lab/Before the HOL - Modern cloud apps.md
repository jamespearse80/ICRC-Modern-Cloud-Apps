![](https://github.com/Microsoft/MCW-Template-Cloud-Workshop/raw/master/Media/ms-cloud-workshop.png "Microsoft Cloud Workshops")

<div class="MCWHeader1">
Modern cloud apps
</div>

<div class="MCWHeader2">
Before the hands-on lab setup guide
</div>

<div class="MCWHeader3">
April 2019
</div>

Information in this document, including URL and other Internet Web site references, is subject to change without notice. Unless otherwise noted, the example companies, organizations, products, domain names, e-mail addresses, logos, people, places, and events depicted herein are fictitious, and no association with any real company, organization, product, domain name, e-mail address, logo, person, place or event is intended or should be inferred. Complying with all applicable copyright laws is the responsibility of the user. Without limiting the rights under copyright, no part of this document may be reproduced, stored in or introduced into a retrieval system, or transmitted in any form or by any means (electronic, mechanical, photocopying, recording, or otherwise), or for any purpose, without the express written permission of Microsoft Corporation.

Microsoft may have patents, patent applications, trademarks, copyrights, or other intellectual property rights covering subject matter in this document. Except as expressly provided in any written license agreement from Microsoft, the furnishing of this document does not give you any license to these patents, trademarks, copyrights, or other intellectual property.

The names of manufacturers, products, or URLs are provided for informational purposes only and Microsoft makes no representations and warranties, either expressed, implied, or statutory, regarding these manufacturers or the use of the products with any Microsoft technologies. The inclusion of a manufacturer or product does not imply endorsement of Microsoft of the manufacturer or product. Links may be provided to third party sites. Such sites are not under the control of Microsoft and Microsoft is not responsible for the contents of any linked site or any link contained in a linked site, or any changes or updates to such sites. Microsoft is not responsible for webcasting or any other form of transmission received from any linked site. Microsoft is providing these links to you only as a convenience, and the inclusion of any link does not imply endorsement of Microsoft of the site or the products contained therein.

© 2019 Microsoft Corporation. All rights reserved.

Microsoft and the trademarks listed at <https://www.microsoft.com/en-us/legal/intellectualproperty/Trademarks/Usage/General.aspx> are trademarks of the Microsoft group of companies. All other trademarks are property of their respective owners.# Modern Cloud Apps setup

**Contents**

<!-- TOC -->

- [Modern cloud apps before the hands-on lab setup guide](#modern-cloud-apps-before-the-hands-on-lab-setup-guide)
  - [Requirements](#requirements)
  - [Before the hands-on lab](#before-the-hands-on-lab)
    - [Task 1: Setup a development environment](#task-1-setup-a-development-environment)
    - [Task 2: Disable IE Enhanced Security](#task-2-disable-ie-enhanced-security)
    - [Task 3: Install SQL Server Management Studio](#task-3-install-sql-server-management-studio)
    - [Task 4: Validate connectivity to Azure](#task-4-validate-connectivity-to-azure)
    - [Task 5: Download and explore the Contoso Sports League sample](#task-5-download-and-explore-the-contoso-sports-league-sample)
    - [Task 6: Create a new Azure Resource Group](#task-6-create-a-new-azure-resource-group)

<!-- /TOC -->

# Modern cloud apps before the hands-on lab setup guide 

## Requirements

- Microsoft Azure subscription

- Local machine or Azure virtual machine configured with:

  - Visual Studio 2017 Community Edition or later

## Before the hands-on lab

Duration: 30 minutes

Before initiating the hands-on lab, you will setup an environment to use for the rest of the exercises.

### Task 1: Setup a development environment

1. Create a virtual machine in Azure using the Visual Studio Community 2019 with the on Windows Server 2016 image.

    Click **+Create a resource**.  In the marketplace search type **Visual Studio**.

    ![Search window for resources. Visual Studio 2019 selected.](media/2019-04-19-09-31-16.png "Visual Studio 2019 selected")

    ![The Azure Portal Search field text is Visual Studio Community 2017 on Windows Server 2016 (x64). In the Search results section, Visual Studio Community 2017 on Windows Server 2016 (x64) is selected.](media/2019-04-19-09-26-51.png "Azure Portal, Search results section")

    Enter the Basics configuration.

    - **Resource Group**: Click the **Create new** link. Enter the value **ContosoSports** or some similar unique name.
    - **Virtual machine name**: Enter your machine name.  e.g. **LabVM**
    - **Region**: Select a region close to you.
    - **Image**: Select **Visual Studio Community (latest release) on Windows Server 2016 (x64)**.
    - **Size**: Enter **D2 v3**.
    - **Username**: Enter a username.
    - **Password**: Enter a password.
    - **Inbound ports**: Select RDP on port 3389.

    ![Create a virtual machine.  Enter the configuration for the virtual machine. Basic tab.](media/2019-04-19-09-49-11.png "Create a virtual machine - basic tab")

    ![Create a virtual machine.  Enter inbound port rules.](media/2019-03-31-12-49-41.png "Enter inbound port rules")

    - Click the **Management** tab.
    - Click the **Create new** link. Enter a unique storage account name. e.g. ContosoSports + ``<your initials>``.

    ![Create a virtual machine. Click the management tab. Enter configuration.](media/2019-03-31-12-55-09.png "Click the management tab")

    Click the **Review + create** button. Once validation passes, then click the **Create** button.

    Deployment may take a few minutes.

    ![Create a virtual machine. Your deployment is underway.](media/2019-04-19-09-56-17.png "Your deployment is underway.")

### Task 2: Disable IE Enhanced Security

>**Note**: Sometimes this image has IE ESC already disabled, and sometimes it does not.

1. Connect and log on to the new VM you just created by clicking the **Download RDP file** button.

    ![Azure connect to newly created VM](media/2019-03-31-13-12-31.png "Azure connect to newly created VM")

    ![Remote Desktop Connection dialog. Click the Connect button.](media/2019-04-19-10-00-38.png "Remote Desktop Connection dialog")

2. Enable Internet file downloads.

    - Open **Internet Explorer**.
    - Press **F10** button on your keyboard.
    - Select the **Tools** menu option.
    - Select the **Internet options** menu item.
    - Select the **Security** tab.
    - Click the **Custom level ...** button.

    ![Internet options.  Click the Custom level button.](media/2019-04-19-10-21-11.png "Custom level button")

    - Scroll down to **Downloads** options and enable **File download**.

    ![Security Settings - Internet Zone. Custom level options. Enable file downloads.](media/2019-04-19-10-23-26.png "Enable file downloads")

    - Apply the new setting and click the **OK** button.

### Task 3: Install SQL Server Management Studio

1. On the new VM, download and install the latest version of SQL Server Management Studio from the URL below: [17.9.x as of Nov 2018]. This may take 15-20 minutes.

    <https://msdn.microsoft.com/en-us/library/mt238290.aspx>

    ![Download status dialog](media/2019-04-19-10-29-35.png "Download status dialog")

    ![Installing SQL Server Management Studio dialog.](media/2019-04-19-10-31-08.png "Installing SQL Server Management Studio dialog")

### Task 4: Validate connectivity to Azure

1. Within your new virtual machine, launch Visual Studio, and validate you can login with your Microsoft MSDN Account when prompted. 
   - Click the **Check for an updated license** link.  
   - Click the **Close** button.

    ![Visual Studio Community 2019 license check dialog displayed.](media/2019-04-19-10-39-37.png "Visual Studio Community 2019 license check")

2. Validate connectivity to your Azure subscription. Launch Visual Studio, open Server Explorer from the View menu, and ensure that you can connect to your Azure subscription. Right click on Azure and select **Connect to Microsoft Azure Subscription**. Enter your credentials when prompted.

    ![Visual Studio 2019 starting splash page. Arrow pointing to the Continue without code link](media/2019-04-19-10-44-15.png "Continue without code")

    - Click **View** menu.  Select the **Cloud Explorer** menu item.

    ![Visual Studio 2019 View menu options. Cloud Explorer selected.](media/2019-04-19-10-52-30.png "Cloud Explorer selected")

    >**Note:** You should see your Azure subscriptions.  If you don't see your subscription listed, make sure you are using the correct user account.

    ![Cloud Explorer tree menu. Displaying Azure subscription results.](media/2019-04-19-10-54-53.png "Azure subscription results")


### Task 5: Download and explore the Contoso Sports League sample

1. Create a new folder on your C: drive named **MCW**.

2. Download the sample application from here: <https://github.com/Microsoft/MCW-Modern-cloud-apps/tree/master/Hands-on%20lab/Lab-files/Modern%20Cloud%20Apps%20Student%20Files.zip>  and extract to the newly created **MCW** folder.

3. From the **Contoso Sports League** folder under **MCW**, open the Visual Studio Solution file: **Contoso.Apps.SportsLeague.sln**.

4. The solution contains the following projects:

    |    |            |
    |----------|:-------------:|
    | Contoso.Apps.SportsLeague.Web |   Contoso Sports League e-commerce application |
    | Contoso.Apps.SportsLeague.Admin |   Contoso Sports League call center admin application |
    | Contoso.Apps.Common  |   Shared tier |
    | Contoso.Apps.SportsLeague.Data  |   Shared tier |
    | Contoso.Apps.FunctionApp  |   Function app tier |
    | Contoso.Apps.SportsLeague.Offers |  API for returning list of available products |
    | Contoso.Apps.PaymentGateway   |     API for payment processing |

<h3>You should follow all steps provided *before* performing the Hands-on lab.</h3>
