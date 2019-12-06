![Microsoft Cloud Workshops](https://github.com/Microsoft/MCW-Template-Cloud-Workshop/raw/master/Media/ms-cloud-workshop.png "Microsoft Cloud Workshops")


<div class="MCWHeader1">
ICRC Modern cloud apps
</div>

<div class="MCWHeader2">
Hands-on lab step-by-step
</div>

<div class="MCWHeader3">
December 2019
</div>

Information in this document, including URL and other Internet Web site references, is subject to change without notice. Unless otherwise noted, the example companies, organizations, products, domain names, e-mail addresses, logos, people, places, and events depicted herein are fictitious, and no association with any real company, organization, product, domain name, e-mail address, logo, person, place or event is intended or should be inferred. Complying with all applicable copyright laws is the responsibility of the user. Without limiting the rights under copyright, no part of this document may be reproduced, stored in or introduced into a retrieval system, or transmitted in any form or by any means (electronic, mechanical, photocopying, recording, or otherwise), or for any purpose, without the express written permission of Microsoft Corporation.

Microsoft may have patents, patent applications, trademarks, copyrights, or other intellectual property rights covering subject matter in this document. Except as expressly provided in any written license agreement from Microsoft, the furnishing of this document does not give you any license to these patents, trademarks, copyrights, or other intellectual property.

The names of manufacturers, products, or URLs are provided for informational purposes only and Microsoft makes no representations and warranties, either expressed, implied, or statutory, regarding these manufacturers or the use of the products with any Microsoft technologies. The inclusion of a manufacturer or product does not imply endorsement of Microsoft of the manufacturer or product. Links may be provided to third party sites. Such sites are not under the control of Microsoft and Microsoft is not responsible for the contents of any linked site or any link contained in a linked site, or any changes or updates to such sites. Microsoft is not responsible for webcasting or any other form of transmission received from any linked site. Microsoft is providing these links to you only as a convenience, and the inclusion of any link does not imply endorsement of Microsoft of the site or the products contained therein.

© 2019 Microsoft Corporation. All rights reserved.

Microsoft and the trademarks listed at <https://www.microsoft.com/en-us/legal/intellectualproperty/Trademarks/Usage/General.aspx> are trademarks of the Microsoft group of companies. All other trademarks are property of their respective owners.

**Contents**

<!-- TOC -->
- [Modern cloud apps hands-on lab step-by-step](#modern-cloud-apps-hands-on-lab-step-by-step)
  - [Abstract and learning objectives](#abstract-and-learning-objectives)
  - [Overview](#overview)
  - [Solution architecture](#solution-architecture)
  - [Requirements](#requirements)
  - [Help references](#help-references)
  - [Exercise 1: Deploy Azure Lab VM - Morning Session](#exercise-1-deploy-the-azure-lab-vm)
    - [Task 1: Download GitHub Resources](#task-1-download-github-resources)
    - [Task 2: Deploy Resources to Azure](#task-2-deploy-resources-to-azure)
    - [Task 3: Explore the Contoso Sports League Sample(s)](#task-3-Explore-the-contoso-sports-league-samples)
  - [Exercise 2: Proof of concept deployment - Afternoon Session](#exercise-2-proof-of-concept-deployment)
    - [Task 1: Deploy the e-commerce website, SQL Database, and storage](#task-1-deploy-the-e-commerce-website-sql-database-and-storage)
      - [Subtask 1: Create the Web App and SQL database instance](#subtask-1-create-the-web-app-and-sql-database-instance)
      - [Subtask 2: Provision the storage account](#subtask-2-provision-the-storage-account)
      - [Subtask 3: Update the configuration in the starter project](#subtask-3-update-the-configuration-in-the-starter-project)
      - [Subtask 4: Deploy the e-commerce Web App from Visual Studio](#subtask-4-deploy-the-e-commerce-web-app-from-visual-studio)
    - [Task 2: Setup SQL Database Geo-Replication](#task-2-setup-sql-database-geo-replication)
      - [Subtask 1: Add secondary database](#subtask-1-add-secondary-database)
      - [Subtask 2: Failover secondary SQL database](#subtask-2-failover-secondary-sql-database)
      - [Subtask 3: Test e-commerce Web App after Failover](#subtask-3-test-e-commerce-web-app-after-failover)
      - [Subtask 4: Revert Failover back to Primary database](#subtask-4-revert-failover-back-to-primary-database)
      - [Subtask 5: Test e-commerce Web App after reverting failover](#subtask-5-test-e-commerce-web-app-after-reverting-failover)
    - [Task 3: Deploying the Call Center admin website](#task-3-deploying-the-call-center-admin-website)
      - [Subtask 1: Provision the call center admin Web App](#subtask-1-provision-the-call-center-admin-web-app)
      - [Subtask 2: Update the configuration in the starter project](#subtask-2-update-the-configuration-in-the-starter-project)
      - [Subtask 3: Deploy the call center admin Web App from Visual Studio](#subtask-3-deploy-the-call-center-admin-web-app-from-visual-studio)
    - [Task 4: Deploying the payment gateway](#task-4-deploying-the-payment-gateway)
      - [Subtask 1: Provision the payment gateway API app](#subtask-1-provision-the-payment-gateway-api-app)
      - [Subtask 2: Deploy the Contoso.Apps.PaymentGateway project in Visual Studio](#subtask-2-deploy-the-contosoappspaymentgateway-project-in-visual-studio)
    - [Task 5: Deploying the Offers Web API](#task-5-deploying-the-offers-web-api)
      - [Subtask 1: Provision the Offers Web API app](#subtask-1-provision-the-offers-web-api-app)
      - [Subtask 2: Configure Cross-Origin Resource Sharing (CORS)](#subtask-2-configure-cross-origin-resource-sharing-cors)
      - [Subtask 3: Update the configuration in the starter project](#subtask-3-update-the-configuration-in-the-starter-project-1)
      - [Subtask 4: Deploy the Contoso.Apps.SportsLeague.Offers project in Visual Studio](#subtask-4-deploy-the-contosoappssportsleagueoffers-project-in-visual-studio)
    - [Task 6: Update and deploy the e-commerce website](#task-6-update-and-deploy-the-e-commerce-website)
      - [Subtask 1: Update the Application Settings for the Web App that hosts the Contoso.Apps.SportsLeague.Web project](#subtask-1-update-the-application-settings-for-the-web-app-that-hosts-the-contosoappssportsleagueweb-project)
      - [Subtask 2: Validate App Settings are correct](#subtask-2-validate-app-settings-are-correct)
  - [After the hands-on lab](#after-the-hands-on-lab)
    - [Task 1: Delete resources](#task-1-delete-resources)

<!-- /TOC -->

# Modern cloud apps hands-on lab step-by-step

## Abstract and learning objectives

In this hands-on lab, you will be challenged to implement an end-to-end scenario using a supplied sample that is based on Azure App Services, Azure SQL Database and related services. The scenario will include implementing compute, storage, workflows, and monitoring, using various components of Microsoft Azure.

The hands-on lab can be implemented on your own, but it is highly recommended to pair up with other members working on the lab to model a real-world experience and to allow each member to share their expertise for the overall solution.

By the end of this hands-on lab, you will have learned how to use several key services within Azure to improve overall functionality of the original solution, and to increase the security and scalability of the new and improved design.

## Overview

The Cloud Workshop: Modern Cloud Apps lab is a hands-on exercise that will challenge you to implement an end-to-end scenario using a supplied sample that is based on Microsoft Azure App Services and related services. The scenario will include implementing compute, storage, security, and scale using various components of Microsoft Azure. The lab can be implemented on your own, but it is highly recommended to pair up with additional team members to more closely model a real-world experience, and to allow members to share their expertise for the overall solution.

## Solution architecture

![A diagram that depicts the various Azure PaaS services for the solution. Azure AD Org is used for authentication to the call center app. Azure AD B2C for authentication is used for authentication to the client app. SQL Database for the backend customer data. Azure App Services for the web and API apps. Order processing includes using Functions, Logic Apps, Queues and Storage. Azure App Insights is used for telemetry capture.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image2.png "Solution Architecture Diagram")

## Requirements

1. Microsoft Azure subscription - You will be given an Azure pass code to activate $200 (30-days) worth of credit 
2. Microsoft account - i.e bob.smith@outlook.com

## Help references

|    |            |
|----------|:-------------|
| **Description** | **Links** |
| GitHub | <https://help.github.com/en/github/getting-started-with-github> |
| Azure | <https://azure.microsoft.com/en-us/overview/what-is-azure/> |
| Azure ARM | <https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-group-overview> |
| Azure VM | <https://docs.microsoft.com/en-us/azure/virtual-machines/windows/overview> |
| Azure SQL | <https://docs.microsoft.com/en-us/azure/sql-database/sql-database-technical-overview> |
| SQL firewall | <https://azure.microsoft.com/en-us/documentation/articles/sql-database-configure-firewall-settings/> |
| Deploying a Web App | <https://azure.microsoft.com/en-us/documentation/articles/web-sites-deploy/> |
| Deploying an API app | <https://azure.microsoft.com/en-us/documentation/articles/app-service-dotnet-deploy-api-app/> |
| Accessing an API app from a JavaScript client | <https://azure.microsoft.com/en-us/documentation/articles/app-service-api-javascript-client/> |
| SQL Database Geo-Replication overview | <https://azure.microsoft.com/en-us/documentation/articles/sql-database-geo-replication-overview/> |
| Azure Web Apps authentication | <http://azure.microsoft.com/blog/2014/11/13/azure-websites-authentication-authorization/> |
| View your access and usage reports | <https://msdn.microsoft.com/en-us/library/azure/dn283934.aspx> |
| Detect failures | <https://azure.microsoft.com/en-us/documentation/articles/app-insights-asp-net-exceptions/> |
| Monitor performance problems | <https://azure.microsoft.com/en-us/documentation/articles/app-insights-web-monitor-performance/> |
| Visual Studio | <https://docs.microsoft.com/en-us/visualstudio/windows/?view=vs-2019> |

## Important - Before commencing the hands-on lab you must redeem your Azure pass code

## Redeem FREE Microsoft Azure pass

You should of been given an Azure Pass **"promo code"** - PLEASE ask if you have not 

1. Navigate to the following webpage https://www.microsoftazurepass.com/Home/HowTo 

2. Follow the instuructions to activate Azure pass - **YOU MUST HAVE A MICROSOFT ACCOUNT** i.e bob.smith@outlook.com

## Exercise 1: Deploy the Azure lab VM

Duration: 60 minutes

Before initiating this afternoons hands-on lab, you will setup an environment to use for the rest of the exercises.

### Task 1: Download GitHub resources

1. Open a browser window to the Cloud Workshop GitHub repository (<https://github.com/jamespearse80/ICRC-Modern-Cloud-Apps>).

2. Select **Clone or download**, then select **Download Zip**.

    ![Download Zip from Github repository.](images/Setup/2019-06-24-17-08-18.png)

3. Extract the zip file to your local machine, be sure to keep note of where you have extracted the files. You should now see a set of folders:

    ![Windows Explorer showing the extracted files.](images/Setup/2019-06-24-17-10-56.png)

### Task 2: Deploy resources to Azure

1. Open your Azure Portal.

2. Select **Resource groups**.

3. Select **+Add**.
 
4. Type a resource group name, such as *ContosoSports-[your initials or first name]*.

5. Select **Review + Create**, then select **Create**.

6. Select **Refresh** to see your new resource group displayed and select it.

7. Select **Export template**, and then select **Deploy**.

    ![Select Deploy](images/Setup/2019-06-24-17-15-18.png)

8. Select **Build your own template in the editor**.

9. In the extracted folder, open the `\Hands-on lab\Scripts\template.json` file.

10. Copy and paste it into the window.

11. Select **Save**

12. Select **Edit parameters**

    ![Select Edit Parameters.](images/Setup/2019-06-24-17-17-05.png)

13. In the extracted folder, open the **\Hands-on lab\Scripts\parameters.json** file.

14. Copy and paste it into the window.

15. Select **Save**.

16. Check the **I agree to the terms and conditions stated above** checkbox.

17. Select **Purchase**.

    ![Select Purchase.](images/Setup/2019-06-24-17-20-12.png)

18. The deployment will take **15-30 minutes to complete**. To view the progress, select the **Deployments** link, then select the **Microsoft.Template** deployment.

    ![View template deployment status.](images/Setup/2019-06-24-17-22-19.png "Resource group deployments")

19. **Note**: A configuration script to install SSMS and the require lab files will run after the deployment of the LabVM completes. The task will be listed on the deployment progress screen as `LabVM/CustomScriptExtension`. You should wait for this task to complete before attempting to log into the LabVM in the next task, as it downloads and installs files you will need for the next task.

    ![The CustomScriptExtension task in highlighted in the list of deployment tasks.](media/deployment-progress.png "Deployment progress")

### Task 3: Explore the Contoso Sports League sample

1. Connect to the **LabVM** that was deployed using the previous template using Remote Desktop, using these credentials:

    - **Admin username**: `demouser`
    - **Admin password**: `demo@pass123`

2. Open the `C:\MCW` folder.

3. From the **Contoso Sports League** folder under **MCW**, open the Visual Studio Solution file: `Contoso.Apps.SportsLeague.sln`.

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

You should follow all of the steps provided *before* performing Exercise 2 of todays Hands-on lab.


## Exercise 2: Proof of concept deployment

Duration: 120 minutes

Contoso has asked you to create a proof of concept deployment in Microsoft Azure by deploying the web, database, and API applications for the solution as well as validating that the core functionality of the solution works. Ensure all resources use the same resource group previously created for the App Service Environment.

### Task 1: Deploy the e-commerce website, SQL Database, and storage

In this exercise, you will provision a website via the Azure **Web App + SQL** template using the Microsoft Azure Portal. You will then edit the necessary configuration files in the starter project and deploy the e-commerce website.

#### Subtask 1: Create the Web App and SQL database instance

1. Navigate to the Azure Management portal, [http://portal.azure.com](http://portal.azure.com/), using a new tab or instance and login with your Azure credentials.

2. In the navigation menu to the left, select **+Create a resource** and in the Marketplace search text box, enter **Web App + SQL** and select the appropriate auto-suggestion.

    ![In the Azure Portal on the left, "+Create a resource", search box text and auto-suggestion are surrounded by red boxes.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image11.png "Azure Portal")

3. In the new product blade, select **Create**.

    ![The Web App + SQL blade](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image13.png "Web App + SQL blade")

4. On the Web App blade, specify the following configuration:

   - A unique and valid name (until the green check mark appears). We've used ContosoAp2010. Make note of your selection.

   - Select **contososports** resource group.

   - **ContosoSportsPlan** as a new App Service Plan. Make sure it's in the same location as the **contososports** resource group you created earlier. Use the default **Standard S1** pricing tier.

    ![App Service Plan configuration settings are displayed. The values listed in the instructions are entered into the fields.](media/2019-03-22-11-29-13.png "App Service Plan configuration settings")

    - Select **OK**

5. Select **SQL Database *Configure required settings***, and then **+ Create a new database**.

    ![The tile for the Create a new database option is displayed.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image16.png " Create a new database")

6. On the **SQL Database** blade, specify **ContosSportsDB** as the database name and then select **Target** **Server *Configure required settings***.

    ![Screenshot of the Target Server Configure required settings option.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image18.png "Target Server Configure required settings option")

7. On the **New server** blade, specify the following configuration:

   - Server name: **A unique value (ensure the green checkmark appears)**

   - Server admin login: **demouser**

   - Password and Confirm Password: **Password.1!!**

   - Ensure the **Target server** is the same region as the Web app.

8. Once the values are accepted in the **New server** blade, click **Select**.

    ![Screenshot of the Select button.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image20.png "Select button")

9. On the **SQL Database** blade, click **Select**.

    ![Screenshot of the Select button.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image20.png "Select button")

11. Application Insights should be disabled.

    ![Application Insight configuration. Disabled option selected.](media/2019-04-19-13-24-11.png "Application Insight configuration")

12. After the values are accepted on the **Web App + SQL** creation blade, check select **Create**.

    ![Final web app configuration settings.  Arrow pointing to the Create button.](media/2019-04-19-13-32-16.png "Final web app configuration settings")

    >**Note**: This may take a couple minutes to provision the Web App and SQL Database resources.

    ![The bell icon located at the top of the web page has been clicked.  Notifications message tells you deployment in progress.](media/2019-03-22-11-36-59.png "Check provision progress")

12. After the Web App and SQL Database are provisioned, click **SQL databases** in the left-hand navigation menu followed by the name of the SQL Database you just created and select it.

    ![In the Azure Portal, on the left side, "SQL Databases" is surrounded by a red box. In the right pane, "ContosoSportsDB" is surrounded by a red box](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image22.png "Azure Portal")

13. On the **SQL Database** blade, click the **Show database connection strings** link.

    ![On the SQL Database blade, in the left pane, Overview is selected. In the right pane, under Essentials, the Connection strings (Show database connection strings) link is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image23.png "SQL Database blade")

14. On the **Database connection strings** blade, select and copy the **ADO.NET** connection string. Then, save it in **Notepad** for use later, being sure to replace the placeholders with your username and password with **demouser** and **Password.1!!**, respectively.

    ![In the Database connection strings blade, the ADO.NET connection string is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image24.png "Database connection strings blade")

15. On the **Overview** screen of the **SQL Server** blade, click **Set server firewall** link at the top.

    ![In the SQL Server Blade, Overview section, the Set server firewall tile is in a box.](media/2019-03-31-14-37-31.png "SQL Server Blade, Essentials section")

16. On the **Firewall Settings** blade, specify a new rule named **ALL**, with START IP **0.0.0.0**, and END IP **255.255.255.255**.

    ![Screenshot of the Rule name, Start IP. and End IP fields on the Firewall Settings blade.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image27.png "Firewall Settings blade")

    >**Note**: This is only done to make the lab easier to do. In production, you do **NOT** want to open up your SQL Database to all IP Addresses this way. Instead, you will want to specify just the IP Addresses you wish to allow through the Firewall.

17. Click **Save**.

    ![Screenshot of the Firewall settings Save button.](media/2019-04-10-16-00-29.png "Firewall settings Save button")

18. Update progress can be found by clicking on the **Notifications** link located at the top of the page.

    ![Screenshot of the Success dialog box, which says that the server firewall rules have been successfully updated.](media/2019-04-19-13-39-41.png "Success dialog box")

19. Close all configuration blades.

#### Subtask 2: Provision the storage account

1. Using a new tab or instance of your browser, navigate to the Azure Management portal <http://portal.azure.com>.

2. From the navigation menu to the left, click **Storage Accounts** and then click **+Add** at the top of the new blade.

    ![In the Azure Portal, in the navigation menu on the left, Storage Account is surrounded by a red box. To the right, the "+Add" tile is likewise surrounded](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image30.png "Azure Portal - Storage Accounts")

3. On the **Create storage account** blade, specify the following configuration options:

   - Name: Unique value for the storage account (ensure the green check mark appears).

   - Specify the existing resource group **contososports**.

   - Specify the same **Location** as the Contoso Sports resource group.

   - Accept the defaults for all other settings.

    ![The fields in the Create Storage Account blade are set to the previously defined settings. In addition, the Name field set to contososports2101, Deployment model is Resource Manager, Account kind is General purpose, and Performance is standard.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image31.png "Create Storage Account blade")

4. Click **Review + create**.

    ![Screenshot of the Review + create button.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image32.png "Create button")

5. Click **Create** after Validation passed.

    ![Screenshot of the Create button.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image32a.png "Create button")

6. Once the storage account has completed provisioning, open the storage account by clicking **Storage accounts** in the navigation menu to the left and clicking on the storage account name.

    ![The Storage Account menu link in the Azure Portal.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image33.png "Azure Portal, More services")

7. On the **Storage account** blade, scroll down, and, under the **SETTINGS** menu area, select the **Access keys** option.

    ![In the Storage account blade, under Settings, Access keys is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image35.png "Storage account blade")

8. On the **Access keys** blade, click the copy button by the **Connection String** field in the **key1** section. Paste the value into **Notepad** for later usage. 

    ![In the Access keys blade default keys section, the copy button for the key1 connection string is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image36.png "Access keys blade, default keys section")

#### Subtask 3: Update the configuration in the starter project

1. In the Azure Portal, click on **Resource Groups**. Then, click on the **contososports** resource group.

    ![In the Azure Portal left menu, Resource groups selected. In the Resource groups blade, under Name, contososports is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image37.png "Azure Portal")

2. Click on the **Web App** (App Service type) created previously.

    ![Resources listed for ContosoSports. Web app selected.](media/2019-04-19-13-46-40.png "Resources listed for ContosoSports")

3. Copy the web app URL to Notepad.

    - Click on the **Overview** link.
    - Copy the URL to Notepad for later use. Use the **Copy to clipboard** link.

    ![In the Web App Overview settings, the URL has a box around the link.](media/2019-03-22-16-33-05.png "Contoso Web App Overview")

4. On the **App Service** blade, scroll down in the left pane. Under the **Settings** menu, click on **Configuration**.

    ![In the App Service blade, under Settings, click Configuration link.](media/2019-04-19-16-38-54.png "Configuration link")

6. Add a new **Application setting** with the following values:

   - Key: `AzureQueueConnectionString`

   - Value: Enter the Connection String for the **Azure Storage Account** you just created and saved to your notepad, and then hit OK

    ![In the App settings section for the App Service blade, the new entry for AzureQueueConnectionString is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image40.png "App settings section")

7. Locate **Connection Strings** section below **Application Settings**.

    ![The Connection Strings section for the App Service blade displays.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image41.png "Connection Strings section")

8. Add a new **Connection String** with the following values:

   - Name: `ContosoSportsLeague`

   - Value: **Enter the Connection String for the SQL Database just created**

   - Type: `SQLAzure`

    >**Important**: Ensure you replace the string placeholder values **{your\_username}** **{your\_password\_here}** with the username and password you setup during previously. Please note: make sure you remove the {} brackets

    ![The password string placeholder value displays: Password={your\_password\_here};](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image43.png "String placeholder value")

   - Hit OK

9. Click **Save**.

#### Subtask 4: Deploy the e-commerce Web App from Visual Studio - Using your LabVM

1. Connect to LabVM and open Visual Studio Community edition 2019 (shortcut is on the desktop)

2. Navigate to the **Contoso.Apps.SportsLeague.Web** project located in the **Web** folder using the **Solution Explorer** of Visual Studio.

    ![In Solution Explorer, under Solution \'Contoso.Apps.SportsLeague\' (7 projects), Web is expanded, and under Web, Contoso.Apps.SportsLeague.Web is selected.](media/2019-04-19-14-03-04.png "Solution Explorer")

3. Right-click the **Contoso.Apps.SportsLeague.Web** project, and click **Publish**.

    >Note: Don't publish if the configuration does not show your settings. Choose **New Profile** to publish to your Azure portal.
    > ![Visual Studio Publish configuration left over from developer. A don't publish message is displayed. There is a box around New Profile link.](media/2019-03-22-12-42-48.png "Select New Profile")

4. Choose **Azure App Service** as the publish target, and choose **Select Existing** and then **Publish** at the bottom of the wizard.

    ![On the Publish tab, the Microsoft Azure App Service tile is selected, as is the radio button for Select Existing.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image47.png "Publish tab")

    ![App Service Select Existing App Service dialog is displayed. The Sign In link is highlighted](media/2019-04-19-14-07-19.png "Azure Sign In")

5. If prompted, log on with your Azure Subscription credentials.

    >**Note:** If you Sign In and nothing happens, shut down Visual Studio reopen to the solution. Repeat the publishing steps.

6. Select the **Contoso Sports Web App** (with the name you created previously).

    ![Under Subscriptions, under contososports, contososportsweb0 is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image49.png "Subscriptions")

7. Click **OK**, and click **Publish** to publish the Web application.

8. In the Visual Studio **Output** view, you will see a status that indicates the Web App was published successfully.

    ![Screenshot of the Visual Studio Output view, with the Publish Succeeded message circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image50.png "Visual Studio Output view")

    >**Note:** Your URL will differ from the one shown in the Output screenshot because it has to be globally unique.

9. A new browser should automatically open the new web applications. Validate the website by clicking the **Store** link on the menu. You should see product items. As long as products return, the connection to the database is successful.

    ![Screenshot of the Store link.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image51.png "Store link")

    >**Troubleshooting**: If the web site fails to show products, go back and double check all of your connection string entries and passwords web application settings.

### Task 2: Setup SQL Database Geo-Replication

In this exercise, you will provision a secondary SQL Database and configure Geo-Replication using the Microsoft Azure Portal.

#### Subtask 1: Add secondary database

1. Using a new tab or instance of your browser, navigate to the Azure Management Portal <http://portal.azure.com>.

2. Click **SQL databases** in the navigation menu to the left, and click the name of the SQL Database you created previously.

    ![Screenshot of SQL Databases menu option.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image52.png "SQL Databases")

3. Under the **SETTINGS** menu area, click on **Geo-Replication**.

    ![In the Settings section, Geo-Replication is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image53.png "Settings section")

4. Select the Azure Region to place the Secondary within.

    ![The Geo-Replication blade has a map of the world with locations marked on it. Under the map, Primary is set to West Europe, which on the map has a blue checkmark.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image54.png "Geo-Replication blade")

    The Secondary Azure Region should be the Region Pair for the region the SQL Database is hosted in. Consult <https://docs.microsoft.com/en-us/azure/best-practices-availability-paired-regions> to see which region pair the location you are using for this lab is in.

    >**Note**: If you choose a region that cannot be used as a secondary region, you will not be able to pick a pricing plan. Choose another region.

    ![Wrong geo-replication region selected. Not available options presented.](media/2019-03-30-16-05-25.png "Not available options presented.")

5. On the **Create secondary** blade, select **Secondary Type** as **Readable**.

6. Select **Target server** ***Configure required settings***.

    ![the Target server Configure required settings option is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image55.png "Target server option")

7. On the **New server** blade, specify the following configuration:

   - Server name: **A unique value (ensure the green checkmark appears)**

   - Server admin login: **demouser**

   - Password and Confirm Password: **Password.1!!**

    ![The fields in the New Server blade display with the previously defined settings.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image56.png "New Server blade")

8. Once the values are accepted in the **New server** blade, click **Select**.

    ![Screenshot of the Select button.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image20.png "Select button")

9. On the **Create secondary** blade, select **OK**.

    ![Screenshot of the OK button.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image57.png "OK button")

    > **Note**: The Geo-Replication will take a few minutes to complete.

10. After the Geo-Replication has finished provisioning, select **SQL Databases** in the navigation menu to the left.

    ![The SQL databases option in the Azure Portal navigation menu](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image52.png "SQL Databases")

11. Click the name of the Secondary SQL Database you just created.

    ![In the list of Databases, the ContosoSportsDB secondary replication role is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image58.png "Database list")

12. On the **SQL Database** blade, open the **Show database connection strings** link.

    ![On the SQL database blade, in the Essentials blade, the Connection strings (show database connection strings) link is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image59.png "SQL database blade")

13. On the **Database connection strings** blade, select and copy the **ADO.NET** connection string, and save it in Notepad for use later.

    ![On the Database connection strings blade, ADO.NET tab, the connection string is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image60.png "Database connection strings blade")

14. On the SQL database blade in the Essentials section, click the SQL Database Server name link.

    ![On the SQL database blade in the Essentials section, the Server name (contososqlserver2.database.windows.net) link is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image61.png "SQL database blade, Essentials section")

15. On the **SQL Server** blade, click **Show firewall settings** on the right

    ![On the SQL Server blade, at the top, the Set Server Firewall tile is boxed in red.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image62.png "SQL Server blade, Essentials section")

16. On the **Firewall Settings** blade, specify a new rule named **ALL**, with START IP **0.0.0.0**, and END IP **255.255.255.255**.

    ![On the Firewall Settings blade, in the New rule section, a new rule has been created with the previously defined settings.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image27.png "New rule section ")

17. Click **Save**.

    ![Screenshot of the Firewall settings Save button.](media/2019-04-10-16-00-29.png "Firewall settings Save button")

18. Update progress can be found by clicking on the **Notifications** link located at the top of the page.

    ![Screenshot of the Success dialog box, which says that the server firewall rules have been successfully updated.](media/2019-04-19-13-39-41.png "Success dialog box")

19. Close all configuration blades.

#### Subtask 2: Failover secondary SQL database

1. Using a new tab or instance of your browser, navigate to the Azure Management Portal <http://portal.azure.com>.

2. In the navigation menu to the left, click **SQL databases**, and click the name of the *primary* SQL Database you created previously.

    ![Screenshot of SQL Databases tile](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image52.png "Azure Portal")

3. On the **Settings** blade, click **Geo-Replication**.

    ![On the Settings blade, under Settings, Geo-Replication is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image64.png "Settings section")

4. On the **Geo-Replication** blade, select the *secondary* database.

    ![The Geo-Replication blade has a map of the world with locations marked on it. Under the map, Primary is set to West Europe, which on the map has a blue check mark. Under Secondaries, East US is circled, and on the map displays with a green check mark. A line connects the West Coast (blue) and East Coast (green) check marks.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image65.png "Geo-Replication blade")

5. Click the **Forced Failover** button.

    ![the Forced Failover button is circled on the Secondary database blade.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image66.png "Secondary database blade")

6. On the **Forced Failover** prompt, click **Yes**.

    ![On the East US Secondary database blade, in response to the questing asking if you are sure you want to proceed, the Yes button is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image67.png "Failover prompt")

The failover may take a few minutes to complete. You can continue with the next Subtask modifying the Web App to point to the Secondary SQL Database while the Failover is pending.

#### Subtask 3: Test e-commerce Web App after Failover

1. Once completed, in the Azure Portal, click on **SQL databases**, and select the NEW **ContosoSportsDB** secondary.

    ![On the SQL databases blade, under Name, the ContosoSportsDB Secondary replication role is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image68.png "SQL databases blade")

2. Next, click on **Show database connection strings**, and copy it off thereby replacing the user and password.

    ![On the SQL database blade, on the left Overview is selected. On the right, under Essentials, the Connection strings (Show database connection strings) link is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image69.png "SQL database blade")

3. From the Azure portal, click on **Resource Groups**, and select **contososports**.

    ![In the Azure Portal, on the left, Resource groups is circled. On the right, under Name, contososports is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image37.png "Azure Portal")

4. Click on the **Web App** created earlier.

5. On the **App Service** blade, scroll down in the left pane, and click on **Configuration settings**.

    ![In the App Service blade, under Settings, click Configuration link.](media/2019-04-19-16-38-54.png "Configuration link")

6. Scroll down, and locate the **Connection strings** section.

7. Update the **ContosoSportsLeague** Connection String to the value of the **original Secondary Azure SQL Database**.

    ![On the App Service blade, in the Connection strings section, the ContosoSportsLeague connection string is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image70.png "App Service blade")

    >**Note**: Ensure you replace the string placeholder values **{your\_username}** and **{your\_password\_here}** with the username and password you respectively setup during creation (demouser & Password.1!!).

    ![The password string placeholder value displays: Password={your\_password\_here};](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image43.png "String placeholder values")

8. Click the **Save** button.

9. On the **App Service** blade, click on **Overview**.

    ![Screenshot of Overview menu option](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image71.png "App Service blade")

10. On the **Overview** pane, click on the **URL** for the Web App to open it in a new browser tab.

    ![On the App Service blade, in the Essentials section, the URL (http;//contososportsweb4azurewebsites.net) link is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image72.png "App Service blade Essentials section")

11. After the e-commerce Web App loads in Internet Explorer, click on **STORE** in the top navigation bar of the website.

    ![On the Contoso sports league website navigation bar, the Store button is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image73.png "Contoso sports league website navigation bar")

12. Verify the product list from the database displays.

    ![Screenshot of the Contoso store webpage. Under Team Apparel, a Contoso hat, tank top, and hoodie display.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image74.png "Contoso store webpage")

#### Subtask 4: Revert Failover back to Primary database

1. Using a new tab or instance of your browser, navigate to the Azure Management Portal <http://portal.azure.com>.

2. In the new **SQL databases**, and click the name of the SQL Database you created previously.

    ![Screenshot of SQL Databases menu option.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image52.png "SQL Databases")

3. On the **Settings** blade, click **Geo-Replication**.

    ![In the Settings section, Geo-Replication is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image64.png "Settings section")

4. On the **Geo-Replication** blade, select the Secondary database.

    ![The Geo-Replication blade has a map of the world with locations marked on it. Under the map, Primary is set to East US, which on the map has a blue check mark. Under Secondaries, West Europe is circled, and on the map displays with a green check mark. A line connects the East US (blue) and West Europe (green) check marks.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image75.png "Geo-Replication blade")

5. Click the **Forced Failover** button.

    ![The Forced Failover button in the Secondary Database blade is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image76.png "Secondary Database blade")

6. On the **Forced Failover** prompt, click **Yes**.

    ![On the West Europe Secondary database blade, in response to the questing asking if you are sure you want to proceed, the Yes button is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image77.png "Failover prompt")

The failover may take a few minutes to complete. You can continue with the next Subtask modifying the Web App to point back to the Primary SQL Database while the Failover is pending.

#### Subtask 5: Test e-commerce Web App after reverting failover

1. In the Azure Portal, click on **Resource Groups** **\>** **contososports** resource group.

    ![In the left menu of the Azure Portal, Resource groups is selected. On the right, under Resource groups, contososports is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image37.png "Azure Portal")

2. Click on the **Web App** created in a previous step.

3. On the **App Service** blade, scroll down in the left pane, and click on **Configuration settings**.

    ![In the App Service blade, under Settings, click Configuration link.](media/2019-04-19-16-38-54.png "Configuration link")

4. Scroll down, and locate the **Connection strings** section.

5. Update the **ContosoSportsLeague** Connection String back to the value of the Connection String for the **original Primary SQL Database**.

    ![In the App Service blade Connection strings section, the ContosoSportsLeague connection string is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image70.png "App Service blade")

    > **Note**: Ensure you replace the string placeholder values **{your\_username}** **{your\_password\_here}** with the username and password you respectively setup during creation (demouser & Password.1!!).

    ![The password string placeholder value displays: Password={your\_password\_here};](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image43.png "String placeholder value")

6. Click **Save**.

    ![the Save button is circled on the App Service blade.](media/2019-03-28-05-36-38.png "App Service blade")

7. On the **App Service** blade, click on **Overview**.

    ![Overview is selected on the App Service blade.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image71.png "App Service blade")

8. On the **Overview** pane, click on the **URL** for the Web App to open it in a new browser tab.

    ![In the App Service blade Essentials section, the URL (http:/contososportsweb4.azurewebsites.net) link is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image72.png "App Service blade, Essentials section")

9. After the e-commerce Web App loads in Internet Explorer, click on **STORE** in the top navigation bar of the website.

    ![On the Contoso sports league website navigation bar, the Store button is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image73.png "Contoso sports league website navigation bar")

10. Verify the product list from the database displays.

    ![Screenshot of the Contoso store webpage. Under Team Apparel, a Contoso hat, tank top, and hoodie display.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image74.png "Contoso store webpage")

### Task 3: Deploying the Call Center admin website

In this exercise, you will provision a website via the Azure Web App template using the Microsoft Azure Portal. You will then edit the necessary configuration files in the Starter Project and deploy the call center admin website.

#### Subtask 1: Provision the call center admin Web App 

1. Using a new tab or instance of your browser, navigate to the Azure Management portal <http://portal.azure.com>.

2. Select **+Create a new resource** **\>** **Web** **\>** **Web App**.

   ![In the left menu of the Azure Portal, the New button is selected. In middle section, under Marketplace, Web + mobile is selected. In the right, Web + mobile section, under Featured apps, Web App is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image78.png "Azure Portal")

3. Specify a **unique URL** for the Web App, and ensure the **same App Service Plan** and **resource group** you have used throughout the lab are selected.

    ![On the Web App blade, the App name field is set to contososportsadmin2101](media/2019-03-28-05-29-59.png "Web App blade")

4. Click on **Windows Plan**, and select the **ContosoSportsPlan** used by the front-end Web app.

5. After the values are accepted, click **Review and create**, then **Create**.  It will take a few minutes to provision.

#### Subtask 2: Update the configuration in the starter project

1. Navigate to the **App Service** blade for the Call Center Admin App just provisioned.

    ![The App Service blade displays.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image80.png "App Service blade")

2. On the **App Service** blade, click on **Configuration** in the left pane.

    ![In the App Service blade, under Settings, click Configuration link.](media/2019-04-19-16-38-54.png "Configuration link")

3. Scroll down, and locate the **Connection strings** section.

4. Add a new **Connection string** with the following values:

    - Name: `ContosoSportsLeague`

    - Value: **Enter the Connection String for the primary SQL Database**.

    - Type: `SQL Azure`

    ![The Connection Strings fields display the previously defined values.](media/2019-04-11-04-31-51.png "Connection Strings fields")

    >**Note**: Ensure you replace the string placeholder values **{your\_username}** **{your\_password\_here}** with the username and password you respectively setup during creation (demouser & Password.1!!).

    ![The password string placeholder value displays: Password={your\_password\_here};](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image43.png "String placeholder values")

    - Click the **Update** button.

5. Click the **Save** button.

    ![the Save button is circled on the App Service blade.](media/2019-03-28-05-36-38.png "App Service blade")

#### Subtask 3: Deploy the call center admin Web App from Visual Studio

1. Navigate to the **Contoso.Apps.SportsLeague.Admin** project located in the **Web** folder using the **Solution Explorer** in Visual Studio.

2. Right-click the **Contoso.Apps.SportsLeague.Admin** project, and click **Publish**.

    ![In Solution Explorer, the right-click menu for Contoso.Apps.SportsLeague.Admin displays, and Publish is selected.](media/2019-04-19-14-30-03.png "Right-Click menu")

3. Choose **App Service** as the publish target, choose **Select Existing**, then click **Publish**

    ![On the Publish tab, Microsoft Azure App Service is selected. Below that, the radio button is selected for Select Existing.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image87.png "Publish tab")

4. Select the **Web App** for the Call Center Admin App.

    ![In the App Service section, in the tree view at the bottom, the contososports folder is expanded, and the Call Center Web App is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image88.png "App Service section")

5. Click **OK** to deploy the site.

    ![Display the Visual Studio Contoso.Apps.SportsLeague.Admin publish success message in the output.](media/2019-03-28-05-45-28.png "Publish Succeeded")

6. Once deployment is complete, navigate to the Web App. It should look like the following:

    ![The Contoso website displays the Contoso Sports League Admin webpage, which says that orders that display below are sorted by date, and you can click on an order to see its details. However, at this time, there is no data available under Completed Orders.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image89.png "Contoso website")

### Task 4: Deploying the payment gateway

In this exercise, the attendee will provision an Azure API app template using the Microsoft Azure Portal. The attendee will then deploy the payment gateway API to the API app.

#### Subtask 1: Provision the payment gateway API app

1. Using a new tab or instance of your browser, navigate to the Azure Management Portal <http://portal.azure.com>.

2. Click **+Create a resource**, type **API App** into the marketplace search box, and press **Enter**.  Click the **Create** button.

    ![In the Azure Portal left menu, New is selected. In the New blade, the search field is set to API App.](media/2019-03-28-07-57-54.png "Azure Portal - Create API App")

3. On the new **API App** blade, create the following values:

   - **App name:** Specify a unique name for the App Name.
   - **Subscription:** Your Azure Pass subscription.
   - **Resource Group:** select **Use existing** option.
   - **App Service Plan/Location** Select the same primary region used in previous steps.
   - **Application Insights:** **Disabled**

    ![On the API App blade. Configuration fields are displayed.](media/2019-04-20-14-55-42.png "Configuration fields are displayed")

4. After the values are accepted, click **Create**.  It will take a few minutes to provision.

#### Subtask 2: Deploy the Contoso.Apps.PaymentGateway project in Visual Studio

1. Navigate to the **Contoso.Apps.PaymentGateway** project located in the **APIs** folder using the **Solution Explorer** in Visual Studio.

2. Right-click the **Contoso.Apps.PaymentGateway** project, and click **Publish**.

    ![In Solution Explorer, Contoso.Apps.PaymentGateway is selected, and in its right-click menu, Publish is selected.](media/2019-04-19-14-52-22.png "Solution Explorer")

3. On the **Publish Web** dialog box, select **Azure App Service**, then choose **Select Existing**, and **Publish**.

    > **Note**: If your Azure resource group does not show, choose **New Profile**.

4. Select the Payment Gateway API app created earlier, click **OK**.

    ![In the App Service section, the contososports folder is expanded, and PaymentsAPIO is selected. ](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image98.png "App Service section")

5. In the Visual Studio **Output** view, you will see a status indicating the Web App was published successfully.

    ![The Visual Studio output shows that the web app was published successfully. ](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image99.png "Visual Studio output")

6. Copy and paste the gateway **URL** of the deployed **API App** into Notepad for later use.

7. Viewing the Web App in a browser will display the following web page:

   ![Your App Service app is up and running web page displayed](media/2019-04-11-04-58-04.png "App is up and running")

### Task 5: Deploying the Offers Web API

In this exercise, the attendee will provision an Azure API app template using the Microsoft Azure Portal. The attendee will then deploy the Offers Web API.

#### Subtask 1: Provision the Offers Web API app

1. Using a new tab or instance of your browser, navigate to the Azure Management Portal (<http://portal.azure.com>).

2. In the navigation menu to the left, select **+Create a resource** -\> **Web** -\> **API App**.

3. On the new **API App** blade, specify a unique name for the **API App**, and ensure the previously used Resource Group and App Service Plan are selected.

    ![In the API App blade, offersapith is typed in the App name field. App configuration fields displayed.](media/2019-04-11-05-03-33.png "API App blade")

4. After the values are accepted, click the **Create** button.

5. When the Web App template has completed provisioning, open the new API App by, in the navigation menu to the left,
click **App Services** and then clicking the Offer API app you just created.

   ![In the Azure Portal, on the left More services is selected, and on the right under Web + Mobile, App Services displays.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image101.png "Azure Portal, More Services")

#### Subtask 2: Configure Cross-Origin Resource Sharing (CORS)

1. On the **App Service** blade for the Offers API, under the **API** menu section, scroll down and click **CORS**.

    ![In the App Service blade, under API, CORS is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image102.png "App Service blade")

2. In the **Allowed Origins** text box, specify `*` to allow all origins, and click **Save**.

    >**Note**: You should not normally do this in a production environment.

    ![CORS configuration blade displayed.  Entering * as the Allowed Origins value.](media/2019-03-28-08-20-57.png "CORS configuration blade")

#### Subtask 3: Update the configuration in the starter project

1. On the **App Service** blade for the Offers API, click on **Configuration**.

    ![In the App Service blade, under Settings, click Configuration link.](media/2019-04-19-16-38-54.png "Configuration link")

2. In the **Connection Strings** section, add a new **Connection string** with the following values:

      - Name: `ContosoSportsLeague`

      - Value: **Enter the Connection String for the SQL Database that was created**.

      - Type: `SQL Azure`

        ![The Connection Strings fields display the previously defined values.](media/2019-04-11-04-31-51.png "Connection Strings fields")

        >**Note**: Ensure you replace the string placeholder values **{your\_username}** **{your\_password\_here}** with the username and password you respectively setup during creation (demouser & Password.1!!).

        ![The password string placeholder value displays: Password={your\_password\_here};](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image43.png "String placeholder value")

      - Click the **Update** button.

3. Click the **Save** button.

    ![The Save button is circled on the App Service blade.](media/2019-03-28-05-36-38.png "App Service blade")

#### Subtask 4: Deploy the Contoso.Apps.SportsLeague.Offers project in Visual Studio

1. Navigate to the **Contoso.Apps.SportsLeague.Offers** project located in the **APIs** folder using the **Solution Explorer** in Visual Studio.

2. Right-click the **Contoso.Apps.SportsLeague.Offers** project, and select **Publish**.

    ![In Solution Explorer, from the Contoso.Apps.SportsLeague.Admin right-click menu, Publish is selected.](media/2019-04-19-15-03-45.png "Solution Explorer")

3. On the **Publish Web** dialog box, click **Azure App Service**, choose **Select Existing**, and select **Publish**.

    ![On the Publish tab, the Microsoft Azure App Service tile is selected, and under it, the radio button for Select Existing is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image109.png "Publish tab")

4. Select the Offers API app created earlier, and click **OK** **\>** **Publish**.

    ![In the App Service section, the contososports folder is expanded, and OffersAPI4 is selected. ](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image110.png "App Service section")

5. In the Visual Studio **Output** view, you will see a status the API app was published successfully.

6. Record the value of the deployed API app URL into Notepad for later use.

7. Your browser should open and display the following web page:

   ![Your App Service app is up and running web page displayed](media/2019-04-11-05-20-40.png "App is up and running")

### Task 6: Update and deploy the e-commerce website

#### Subtask 1: Update the Application Settings for the Web App that hosts the Contoso.Apps.SportsLeague.Web project

1. Using a new tab or instance of your browser, navigate to the Azure Management Portal <http://portal.azure.com>.

2. Click on **Resource groups** **\>** **contososports** resource group.

    ![In the Azure Portal left menu, Resource groups is selected. On the right, under Resource groups, under Name, contososports is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image112.png "Azure Portal")

3. Click on the **App Service Web App** for the front-end web application.

    ![In the Resource Group blade on the right, under Name, contososportsweb2101 is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image113.png "Resource Group blade")

4. On the **App Service** blade, scroll down, and click on **Configuration** in the left pane.

    ![In the App Service blade, under Settings, click Configuration link.](media/2019-04-19-16-38-54.png "Configuration link")

5. Scroll down, and locate the **Applications settings** section.

    ![The App settings section of the App Service blade displays with AzureQueueConnectionString selected. ](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image115.png "App settings section")

6. Add a new **Application Setting** with the following values:

   - App Setting Name: `paymentsAPIUrl`

   - Value: Enter the **HTTPS** URL for the Payments API App with `/api/nvp` appended to the end.

        >**Example**: `https://paymentsapi0.azurewebsites.net/api/nvp`

    ![In the Application settings section of the App Service blade, the previously defined application setting values are selected. ](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image116.png "App settings")

7. Add another **Application Setting** with the following values:

   - App Setting Name: `offersAPIUrl`

   - Value: Enter the **HTTPS** URL for the Offers API App with `/api/get` appended to the end

    >**Example**: `https://offersapi4.azurewebsites.net/api/get`

    ![In the Application settings section of the App Service blade, the previously defined application setting values are selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image117.png "App settings section")

    >**Note**: Ensure both of the API URLs are using **SSL** (https://), or you will see a CORS errors.

8. Click on **Save**.

#### Subtask 2: Validate App Settings are correct

1. On the **App Service** blade, click on **Overview**.

    ![Overview is selected on the left side of the App Service blade.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image119.png "App Service blade")

2. In the **Overview** pane, click on the **URL** for the Web App to open it in a new browser tab.

    ![On the right side of the App Service blade, under Essentials, the URL (http://contososportsweb2101.azurewebsites.net) link is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image120.png "App Service blade")

3. On the homepage, you should see the latest offers populated from the Offers API.

    ![On the Contoso Sports League webpage, Today\'s offers display: Baseball socks, Road bike, and baseball mitt.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image121.png "Contoso Sports League webpage")

4. Submit several test orders to ensure all pieces of the site are functional.  **Accept the default data during the payment processing.**

    ![On the Contoso Sports League webpage, the message Order Completed displays.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image122.png "Contoso Sports League webpage")

>**Leader Note:** If the attendee is still experiencing CORS errors, ensure the URLs to the Web App in Azure local host are exact.

## After the hands-on lab

Duration: 10 minutes

### Task 1: Delete resources

1. Since the HOL is now complete, go ahead and delete all of the Resource Groups that were created for this HOL. You will no longer need those resources and it will be beneficial to clean up your Azure Subscription.

You should follow all steps provided *after* attending the hands-on lab.
