![](https://github.com/Microsoft/MCW-Template-Cloud-Workshop/raw/master/Media/ms-cloud-workshop.png "Microsoft Cloud Workshops")


<div class="MCWHeader1">
Modern cloud apps
</div>

<div class="MCWHeader2">
Hands-on lab step-by-step
</div>

<div class="MCWHeader3">
September 2018
</div>

Information in this document, including URL and other Internet Web site references, is subject to change without notice. Unless otherwise noted, the example companies, organizations, products, domain names, e-mail addresses, logos, people, places, and events depicted herein are fictitious, and no association with any real company, organization, product, domain name, e-mail address, logo, person, place or event is intended or should be inferred. Complying with all applicable copyright laws is the responsibility of the user. Without limiting the rights under copyright, no part of this document may be reproduced, stored in or introduced into a retrieval system, or transmitted in any form or by any means (electronic, mechanical, photocopying, recording, or otherwise), or for any purpose, without the express written permission of Microsoft Corporation.

Microsoft may have patents, patent applications, trademarks, copyrights, or other intellectual property rights covering subject matter in this document. Except as expressly provided in any written license agreement from Microsoft, the furnishing of this document does not give you any license to these patents, trademarks, copyrights, or other intellectual property.

The names of manufacturers, products, or URLs are provided for informational purposes only and Microsoft makes no representations and warranties, either expressed, implied, or statutory, regarding these manufacturers or the use of the products with any Microsoft technologies. The inclusion of a manufacturer or product does not imply endorsement of Microsoft of the manufacturer or product. Links may be provided to third party sites. Such sites are not under the control of Microsoft and Microsoft is not responsible for the contents of any linked site or any link contained in a linked site, or any changes or updates to such sites. Microsoft is not responsible for webcasting or any other form of transmission received from any linked site. Microsoft is providing these links to you only as a convenience, and the inclusion of any link does not imply endorsement of Microsoft of the site or the products contained therein.

© 2018 Microsoft Corporation. All rights reserved.

Microsoft and the trademarks listed at <https://www.microsoft.com/en-us/legal/intellectualproperty/Trademarks/Usage/General.aspx> are trademarks of the Microsoft group of companies. All other trademarks are property of their respective owners.

**Contents**

<!-- TOC -->

- [Modern cloud apps hands-on lab step-by-step](#modern-cloud-apps-hands-on-lab-step-by-step)
    - [Abstract and learning objectives](#abstract-and-learning-objectives)
    - [Overview](#overview)
    - [Solution architecture](#solution-architecture)
    - [Requirements](#requirements)
    - [Help references](#help-references)
    - [Exercise 1: Proof of concept deployment](#exercise-1-proof-of-concept-deployment)
        - [Task 1: Deploy the e-commerce website, SQL Database, and storage](#task-1-deploy-the-e-commerce-website-sql-database-and-storage)
            - [Subtask 1: Create the Web App and SQL database instance](#subtask-1-create-the-web-app-and-sql-database-instance)
            - [Subtask 2: Provision the storage account](#subtask-2-provision-the-storage-account)
            - [Subtask 3: Update the configuration in the starter project](#subtask-3-update-the-configuration-in-the-starter-project)
            - [Subtask 4: Deploy the e-commerce Web App from Visual Studio](#subtask-4-deploy-the-e-commerce-web-app-from-visual-studio)
        - [Task 2: Setup SQL Database Geo-Replication](#task-2-setup-sql-database-geo-replication)
            - [Subtask 1: Add secondary database](#subtask-1-add-secondary-database)
            - [Subtask 2: Failover secondary SQL database -- OPTIONAL](#subtask-2-failover-secondary-sql-database----optional)
            - [Subtask 3: Test e-commerce Web App after Failover](#subtask-3-test-e-commerce-web-app-after-failover)
            - [Subtask 4: Revert Failover back to Primary database](#subtask-4-revert-failover-back-to-primary-database)
            - [Subtask 5: Test e-commerce Web App after reverting failover](#subtask-5-test-e-commerce-web-app-after-reverting-failover)
        - [Task 3: Deploying the call center admin website](#task-3-deploying-the-call-center-admin-website)
            - [Subtask 1: Provision the call center admin Web App](#subtask-1-provision-the-call-center-admin-web-app)
            - [Subtask 2: Update the configuration in the starter project](#subtask-2-update-the-configuration-in-the-starter-project)
            - [Subtask 3: Deploy the call center admin Web App from Visual Studio](#subtask-3-deploy-the-call-center-admin-web-app-from-visual-studio)
        - [Task 4: Deploying the payment gateway](#task-4-deploying-the-payment-gateway)
            - [Subtask 1: Provision the payment gateway API app](#subtask-1-provision-the-payment-gateway-api-app)
            - [Subtask 2: Deploy the Contoso.Apps.PaymentGateway project in Visual Studio](#subtask-2-deploy-the-contosoappspaymentgateway-project-in-visual-studio)
        - [Task 5: Deploying the offers Web API](#task-5-deploying-the-offers-web-api)
            - [Subtask 1: Provision the Offers Web API app](#subtask-1-provision-the-offers-web-api-app)
            - [Subtask 2: Configure cross-origin resource sharing (CORS)](#subtask-2-configure-cross-origin-resource-sharing-cors)
            - [Subtask 3: Update the configuration in the starter project](#subtask-3-update-the-configuration-in-the-starter-project-1)
            - [Subtask 4: Deploy the Contoso.Apps.SportsLeague.Offers project in Visual Studio](#subtask-4-deploy-the-contosoappssportsleagueoffers-project-in-visual-studio)
        - [Task 6: Update and deploy the e-commerce website](#task-6-update-and-deploy-the-e-commerce-website)
            - [Subtask 1: Update the Application Settings for the Web App that hosts the Contoso.Apps.SportsLeague.Web project](#subtask-1-update-the-application-settings-for-the-web-app-that-hosts-the-contosoappssportsleagueweb-project)
            - [Subtask 2: Validate App Settings are correct](#subtask-2-validate-app-settings-are-correct)
    - [Exercise 2: Identity and security](#exercise-2-identity-and-security)
        - [Task 1: Enable Azure AD Premium Trial](#task-1-enable-azure-ad-premium-trial)
        - [Task 2: Create a new Contoso user](#task-2-create-a-new-contoso-user)
        - [Task 3: Configure access control for the call center administration Web Application](#task-3-configure-access-control-for-the-call-center-administration-web-application)
            - [Subtask 1: Enable Azure AD Authentication](#subtask-1-enable-azure-ad-authentication)
            - [Subtask 2: Verify the call center administration website uses the access control logon](#subtask-2-verify-the-call-center-administration-website-uses-the-access-control-logon)
        - [Task 4: Apply custom branding for the Azure Active Directory logon page](#task-4-apply-custom-branding-for-the-azure-active-directory-logon-page)
        - [Task 5: Verify the branding has been successfully applied to the Azure Active Directory logon page](#task-5-verify-the-branding-has-been-successfully-applied-to-the-azure-active-directory-logon-page)
    - [Exercise 3: Enable Azure B2C for customer site](#exercise-3-enable-azure-b2c-for-customer-site)
        - [Task 1: Create a new directory](#task-1-create-a-new-directory)
        - [Task 2: Add a new application](#task-2-add-a-new-application)
        - [Task 3: Create Policies, Sign up](#task-3-create-policies-sign-up)
        - [Task 4: Create a sign-in policy](#task-4-create-a-sign-in-policy)
        - [Task 5: Create a profile editing policy](#task-5-create-a-profile-editing-policy)
        - [Task 6: Modify the Contoso.App.SportsLeague.Web](#task-6-modify-the-contosoappsportsleagueweb)
        - [Task 7: Send authentication requests to Azure AD](#task-7-send-authentication-requests-to-azure-ad)
        - [Task 8: Display user information](#task-8-display-user-information)
        - [Task 9: Run the sample app](#task-9-run-the-sample-app)
    - [Exercise 4: Enabling Telemetry with Application Insights](#exercise-4-enabling-telemetry-with-application-insights)
        - [Task 1: Configure the application for telemetry](#task-1-configure-the-application-for-telemetry)
            - [Subtask 1: Add Application Insights Telemetry to the e-commerce website project](#subtask-1-add-application-insights-telemetry-to-the-e-commerce-website-project)
            - [Subtask 2: Enable client side telemetry](#subtask-2-enable-client-side-telemetry)
            - [Subtask 3: Deploy the e-commerce Web App from Visual Studio](#subtask-3-deploy-the-e-commerce-web-app-from-visual-studio)
        - [Task 2: Creating the web performance test and load test](#task-2-creating-the-web-performance-test-and-load-test)
            - [Subtask 1: Create the load test](#subtask-1-create-the-load-test)
            - [Subtask 2: View the Application Insights logs](#subtask-2-view-the-application-insights-logs)
    - [Exercise 5: Automating backend processes with Azure Functions and Logic Apps](#exercise-5-automating-backend-processes-with-azure-functions-and-logic-apps)
        - [Task 1: Create an Azure Function to Generate PDF Receipts](#task-1-create-an-azure-function-to-generate-pdf-receipts)
        - [Task 2: Create an Azure Logic App to Process Orders](#task-2-create-an-azure-logic-app-to-process-orders)
        - [Task 3: Use Twilio to send SMS Order Notifications](#task-3-use-twilio-to-send-sms-order-notifications)
            - [Subtask 1: Configure your Twilio trial account](#subtask-1-configure-your-twilio-trial-account)
            - [Subtask 2: Create a new logic app](#subtask-2-create-a-new-logic-app)
    - [After the hands-on lab](#after-the-hands-on-lab)
        - [Task 1: Delete resources](#task-1-delete-resources)

<!-- /TOC -->

# Modern cloud apps hands-on lab step-by-step 

## Abstract and learning objectives 

In this hands-on lab, you will be challenged to implement an end-to-end scenario using a supplied sample that is based on Azure App Services, Microsoft Azure Functions, Azure SQL Database, Azure Logic Apps, and related services. The scenario will include implementing compute, storage, workflows, and monitoring, using various components of Microsoft Azure. 

Please note that as opposed to the Whiteboard Design Session, the lab is not focused on maintaining PCI compliance and using more advanced security features such as App Service Environment, Network Security Groups, and Application Gateway. The hands-on lab can be implemented on your own, but it is highly recommended to pair up with other members working on the lab to model a real-world experience and to allow each member to share their expertise for the overall solution.

By the end of this hands-on lab, you will have learned how to use several key services within Azure to improve overall functionality of the original solution, and to increase the security and scalability of the new and improved design.

## Overview

The Cloud Workshop: Modern Cloud Apps lab is a hands-on exercise that will challenge you to implement an end-to-end scenario using a supplied sample that is based on Microsoft Azure App Services and related services. The scenario will include implementing compute, storage, security, and scale using various components of Microsoft Azure. The lab can be implemented on your own, but it is highly recommended to pair up with other team members to model a real-world experience much closer and to allow each member to share their expertise for the overall solution.

## Solution architecture

![A diagram that depicts the various Azure PaaS services for the solution. Azure AD Org is used for authentication to the call center app. Azure AD B2C for authentication is used for authentication to the client app. SQL Database for the backend customer data. Azure App Services for the web and API apps. Order processing includes using Functions, Logic Apps, Queues and Storage. Azure App Insights is used for telemetry capture.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image2.png "Solution Architecture Diagram")

## Requirements

1.  Microsoft Azure subscription

2.  Local machine or a virtual machine configured with:

    -  Visual Studio 2017 Community Edition
    
## Help references

|    |            |
|----------|:-------------|
| **Description** | **Links** |
| SQL firewall | <https://azure.microsoft.com/en-us/documentation/articles/sql-database-configure-firewall-settings/> |
| Deploying a Web App | <https://azure.microsoft.com/en-us/documentation/articles/web-sites-deploy/> |
| Deploying an API app | <https://azure.microsoft.com/en-us/documentation/articles/app-service-dotnet-deploy-api-app/> |
| Accessing an API app from a JavaScript client | <https://azure.microsoft.com/en-us/documentation/articles/app-service-api-javascript-client/> |
| SQL Database Geo-Replication overview | <https://azure.microsoft.com/en-us/documentation/articles/sql-database-geo-replication-overview/> |
| What is Azure AD? | <https://azure.microsoft.com/en-us/documentation/articles/active-directory-whatis/> |
| Azure Web Apps authentication | <http://azure.microsoft.com/blog/2014/11/13/azure-websites-authentication-authorization/> |
| View your access and usage reports | <https://msdn.microsoft.com/en-us/library/azure/dn283934.aspx> |
| Custom branding an Azure AD Tenant | <https://msdn.microsoft.com/en-us/library/azure/Dn532270.aspx> |
| Service Principal Authentication | <https://docs.microsoft.com/en-us/azure/app-service-api/app-service-api-dotnet-service-principal-auth> |
| Consumer Site B2C | <https://docs.microsoft.com/en-us/azure/active-directory-b2c/active-directory-b2c-devquickstarts-web-dotnet> |
| Getting Started with Active Directory B2C | <https://azure.microsoft.com/en-us/trial/get-started-active-directory-b2c/> |
| How to Delete an Azure Active Directory | <https://blog.nicholasrogoff.com/2017/01/20/how-to-delete-an-azure-active-directory-add-tenant/> |
| Run performance tests on your app | <http://blogs.msdn.com/b/visualstudioalm/archive/2015/09/15/announcing-public-preview-for-performance-load-testing-of-azure-webapp.aspx> |
| Application Insights Custom Events | <https://azure.microsoft.com/en-us/documentation/articles/app-insights-api-custom-events-metrics/> |
| Enabling Application Insights | <https://azure.microsoft.com/en-us/documentation/articles/app-insights-start-monitoring-app-health-usage/> |
| Detect failures | <https://azure.microsoft.com/en-us/documentation/articles/app-insights-asp-net-exceptions/> |
| Monitor performance problems | <https://azure.microsoft.com/en-us/documentation/articles/app-insights-web-monitor-performance/> |
| Creating a Logic App | <https://azure.microsoft.com/en-us/documentation/articles/app-service-logic-create-a-logic-app/> |
| Logic app connectors | <https://azure.microsoft.com/en-us/documentation/articles/app-service-logic-connectors-list/> |
| Logic Apps Docs | <https://docs.microsoft.com/en-us/azure/logic-apps/logic-apps-what-are-logic-apps> |
| Azure Functions -- create first function | <https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-first-azure-function> |
| Azure Functions docs | <https://docs.microsoft.com/en-us/azure/logic-apps/logic-apps-azure-functions> |
|

## Exercise 1: Proof of concept deployment

Duration: 60 minutes

Contoso has asked you to create a proof of concept deployment in Microsoft Azure by deploying the web, database, and API applications for the solution as well as validating that the core functionality of the solution works. Ensure all resources use the same resource group previously created for the App Service Environment.

### Task 1: Deploy the e-commerce website, SQL Database, and storage

In this exercise, you will provision a website via the Azure **Web App + SQL** template using the Microsoft Azure Portal. You will then edit the necessary configuration files in the starter project and deploy the e-commerce website.

#### Subtask 1: Create the Web App and SQL database instance

1.  Navigate to the Azure Management portal, [http://portal.azure.com](http://portal.azure.com/), using a new tab or instance and login with your lab-provided Azure credentials.

2.  In the navigation menu to the left, click **+ Create a resource** and in the Marketplace search text box, enter **Web App + SQL** and select the appropriate auto-suggestion.

    ![In the Azure Portal on the left, "+ Create a resource", search box text and auto-suggestion are surrounded by red boxes.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image11.png "Azure Portal")

3.  In the new product blade, click **Create**.

    ![The Web App + SQL blade](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image13.png "Web App + SQL blade")


4.  On the Web App blade, specify the following configuration:

    -  A unique and valid name (until the green check mark appears).

    -  Select **contososports** resource group.

    -  **ContosoSportsPlan** as a new App Service Plan. Make sure it's in the same location as the **contososports** resource group. Use the default **Standard S1** pricing tier. 

    ![The Web App + SQL blade, App Service plan, and New App Service Plan blades display, with fields set to the previously defined settings. In the Web App + SQL blade, the App name field is selected, and is set to contosoap2101. Resource group is selected, as is the App Service plan/location. In the App Service plan blade, on the left, the Create New button is selected. In the App Service plan blade, the App Service plan field is set to ContosoSportsPlan, and the Location field is set to South Central US.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image15.png "Web App + SQL blade")

5. Select **SQL Database *Configure required settings***, and then click **+ Create a new database**.

    ![The tile for the Create a new database option is displayed.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image16.png " Create a new database")

6. On the **SQL Database** blade, specify **ContosSportsDB** as the database name and then select **Target** **Server *Configure required settings***.

    ![Screenshot of the Target Server Configure required settings option.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image18.png "Target Server Configure required settings option")

7. On the **New server** blade, specify the following configuration:

    -  Server name: **A unique value (ensure the green checkmark appears)**.

    -  Server admin login: **demouser**

    -  Password and Confirm Password: **Password.1!!**

    -  Ensure the **Location** is the same region as the Web App.

    ![Fields in the New server blade are circled and set to the previously defined settings.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image19.png "New server blade")

8. Once the values are accepted in the **New server** blade, click **Select**.

    ![Screenshot of the Select button.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image20.png "Select button")

9. On the **SQL Database** blade, click **Select**.

    ![Screenshot of the Select button.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image20.png "Select button")

10. After the values are accepted on the **Web App + SQL** creation blade, check click **Create**.

    ![Screenshot of the Create button.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image21.png "Create button")

    > **Note**: This may take a couple minutes to provision the Web App and SQL Database resources.

11. After the Web App and SQL Database are provisioned, click **SQL databases** in the left-hand navigation menu followed by the name of the SQL Database you just created.

    ![In the Azure Portal, on the left side, "SQL Databases" is surrounded by a red box. In the right pane, "ContosoSportsDB" is surrounded by a red box](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image22.png "Azure Portal")

12. On the **SQL Database** blade, click the **Show database connection strings** link.

    ![On the SQL Database blade, in the left pane, Overview is selected. In the right pane, under Essentials, the Connection strings (Show database connection strings) link is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image23.png "SQL Database blade")

13. On the **Database connection strings** blade, select and copy the **ADO.NET** connection string. Then, save it in **Notepad** for use later, being sure to replace the placeholders with your username and password with **demouser** and **Password.1!!**, respectively.

    ![In the Database connection strings blade, the ADO.NET connection string is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image24.png "Database connection strings blade")

14. On the **Overview** screen of the **SQL Server** blade, click **Set Server Firewall**.

    ![In the SQL Server Blade, Overview section, the Set server firewall tile is in a red box.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image25.png "SQL Server Blade, Essentials section")

15. On the **Firewall Settings** blade, specify a new rule named **ALL**, with START IP **0.0.0.0**, and END IP **255.255.255.255**.

    ![Screenshot of the Rule name, Start IP. and End IP fields on the Firewall Settings blade.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image27.png "Firewall Settings blade")

    > **Note**: This is only done to make the lab easier to do. In production, you do **NOT** want to open up your SQL Database to all IP Addresses this way. Instead, you will want to specify just the IP Addresses you wish to allow through the Firewall.

16. Click **Save**.

    ![Screenshot of the Firewall settings Save button.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image28.png "Firewall settings Save button")

17. On the **Success!** dialog box, click **OK**.

    ![Screenshot of the Success dialog box, which says that the server firewall rules have been successfully updated.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image29.png "Success dialog box")

18. Close all configuration blades.

#### Subtask 2: Provision the storage account

1.  Using a new tab or instance of your browser, navigate to the Azure Management portal <http://portal.azure.com>.

2.  From the navigation menu to the left, click **+ Create a resource**, **Storage Accounts** and then click **+ Add** at the top of the new blade.

    ![In the Azure Portal, in the navigation menu on the left, Storage Account is surrounded by a red box. To the right, the "+ Add" tile is likewise surrounded](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image30.png "Azure Portal - Storage Accounts")

3.  On the **Create storage account** blade, specify the following configuration options:

    -  Name: Unique value for the storage account (ensure the green check mark appears).

    -  Specify the existing Resource Group **contososports**.

    -  Specify the same **Location** as the resource group.

    -  Accept the defaults for all other settings.

    ![The fields in the Create Storage Account blade are set to the previously defined settings. In addition, the Name field set to contososports2101, Deployment model is Resource Manager, Account kind is General purpose, and Performance is standard.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image31.png "Create Storage Account blade")

4.  Click **Review + create**.

    ![Screenshot of the Create button.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image32.png "Create button")

5.  Once the storage account has completed provisioning, open the storage account by clicking **Storage accounts** in the navigation menu to the left and clicking on the storage account name.

    ![The Storage Account menu link in the Azure Portal.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image33.png "Azure Portal, More services")

6.  On the **Storage account** blade, scroll down, and, under the **SETTINGS** menu area, select the **Access keys** option.

    ![In the Storage account blade, under Settings, Access keys is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image35.png "Storage account blade")

7.  On the **Access keys** blade, click the copy button by the **Connection String** field in the **key1** section. Paste the value into **Notepad** for later usage. 

    ![In the Access keys blade default keys section, the copy button for the key1 connection string is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image36.png "Access keys blade, default keys section")

#### Subtask 3: Update the configuration in the starter project

1.  In the Azure Portal, click on **Resource Groups**. Then, click on the **contososports** resource group.

    ![In the Azure Portal left menu, Resource groups selected. In the Resource groups blade, under Name, contososports is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image37.png "Azure Portal")

2.  Click on the **Web App** just created in a previous step.

3.  On the **App Service** blade, scroll down in the left pane, and, under the **SETTINGS** menu, click on **Application settings**.

    ![In the App Service blade, under Settings, Application settings is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image38.png "App Service blade")

4.  Scroll down, and locate the **Application settings** section.

    ![The App settings section from the App Service blade displays.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image39.png "App Service blade")

5.  Add a new **Application setting** with the following values:

    -  Key: **AzureQueueConnectionString**

    -  Value: **Enter the Connection String for the Azure Account just created**.

    ![In the App settings section for the App Service blade, the new entry for AzureQueueConnectionString is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image40.png "App settings section")

6.  Locate **Connection Strings** below **Application Settings**.

    ![The Connection Strings section for the App Service blade displays.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image41.png "Connection Strings section")

7.  Add a new **Connection String** with the following values:

    -  Name: **ContosoSportsLeague**

    -  Value: **Enter the Connection String for the SQL Database just created**.

    -  Type: **SQLAzure**

    Ensure you replace the string placeholder values **{your\_username}** **{your\_password\_here}** with the username and password you respectively setup during creation (demouser AND Password.1!!).
    
    ![The password string placeholder value displays: Password={your\_password\_here};](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image43.png "String placeholder value")

8.  Click **Save**.

    ![On the App Service blade, the Save button selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image44.png "App Service blade")

#### Subtask 4: Deploy the e-commerce Web App from Visual Studio

1.  Navigate to the **Contoso.Apps.SportsLeague.Web** project located in the **Web** folder using the **Solution Explorer** of Visual Studio.

    ![In Solution Explorer, under Solution \'Contoso.Apps.SportsLeague\' (7 projects), Web is expanded, and under Web, Contoso.Apps.SportsLeague.Web is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image45.png "Solution Explorer")

2.  Right-click the **Contoso.Apps.SportsLeague.Web** project, and click **Publish**.

    ![In Solution Explorer, Contoso.Apps.SportsLeague.Web is selected, and from its right-click menu, Publish is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image46.png "Solution Explorer")

3.  Choose **Microsoft Azure App Service** as the publish target, and choose **Select Existing**.

![On the Publish tab, the Microsoft Azure App Service tile is selected, as is the radio button for Select Existing.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image47.png "Publish tab")

4.  If prompted, log on with your credentials, and ensure the subscription you published earlier are selected.

    ![Screenshot of the Microsoft account subscriptions tile.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image48.png "Microsoft account tile")

5.  Select the **Contoso Sports Web App**.

    ![Under Subscriptions, under contososports, contososportsweb0 is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image49.png "Subscriptions")

6.  Click **OK**, and click **Publish** to publish the Web Application.

7.  In the Visual Studio **Output** view, you will see a status that indicates the Web App was published successfully.

    ![Screenshot of the Visual Studio Output view, with the Publish Succeeded message circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image50.png "Visual Studio Output view")

8.  Validate the website by clicking the **Store** link on the menu. As long as products return, the connection to the database is successful.

    ![Screenshot of the Store link.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image51.png "Store link")

### Task 2: Setup SQL Database Geo-Replication

In this exercise, the attendee will provision a secondary SQL Database and configure Geo-Replication using the Microsoft Azure Portal.

#### Subtask 1: Add secondary database

1.  Using a new tab or instance of your browser, navigate to the Azure Management Portal <http://portal.azure.com>.

2.  Click **SQL databases** in the navigation menu to the left, and click the name of the SQL Database you created previously.

    ![Screenshot of SQL Databases menu option.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image52.png "SQL Databases")

3.  Under the **SETTINGS** menu area, click on **Geo-Replication**.

    ![In the Settings section, Geo-Replication is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image53.png "Settings section")

4.  Select the Azure Region to place the Secondary within.

    ![The Geo-Replication blade has a map of the world with locations marked on it. Under the map, Primary is set to West US, which on the map has a blue checkmark.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image54.png "Geo-Replication blade")

    The Secondary Azure Region should be the Region Pair for the region the SQL Database is hosted in. Consult https://docs.microsoft.com/en-us/azure/best-practices-availability-paired-regions to see which region pair the location you are using for this lab is in.

5.  On the **Create secondary** blade, select **Secondary Type** as **Readable**.

6.  Select **Target server** ***Configure required settings***.
    
    ![the Target server Configure required settings option is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image55.png "Target server option")

7.  On the **New server** blade, specify the following configuration:

    -  Server name: **A unique value (ensure the green checkmark appears)**.

    -  Server admin login: **demouser**

    -  Password and Confirm Password: **Password.1!!**

    ![The fields in the New Server blade display with the previously defined settings.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image56.png "New Server blade")

8.  Once the values are accepted in the **New server** blade, click **Select**.

    ![Screenshot of the Select button.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image20.png "Select button")

9.  On the **Create secondary** blade, click **OK**.

    ![Screenshot of the OK button.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image57.png "OK button")

10. After the Geo-Replication has finished provisioning, click **SQL Databases** in the navigation menu to the left.

    ![The SQL databases option in the Azure Portal navigation menu](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image52.png "SQL Databases")

11. Click the name of the Secondary SQL Database you just created.

    ![In the list of Databases, the ContosoSportsDB secondary replicatoin role is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image58.png "Database list")

12. On the **SQL Database** blade, click the **Show database connection strings** link.

    ![On the SQL database blade, in the Essentials blade, the Connection strings (show database connection strings) link is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image59.png "SQL database blade")

13. On the **Database connection strings** blade, select and copy the **ADO.NET** connection string, and save it in Notepad for use later.

    ![On the Database connection strings blade, ADO.NET tab, the connection string is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image60.png "Database connection strings blade")

14. On the SQL database blade in the Essentials section,, click the SQL Database Server name link.

    ![On the SQL database blade in the Essentials section, the Server name (contososqlserver2.database.windows.net) link is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image61.png "SQL database blade, Essentials section")

15. On the **SQL Server** blade, click **Set Server Firewall** at the top.

    ![On the SQL Server blade, at the top, the Set Server Firewall tile is boxed in red.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image62.png "SQL Server blade, Essentials section")

16. On the **Firewall Settings** blade, specify a new rule named **ALL**, with START IP **0.0.0.0**, and END IP **255.255.255.255**.

    ![On the Firewall Settings blade, in the New rule section, a new rule has been created with the previously defined settings.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image27.png "New rule section ")

17. Click **Save**.

    ![On the Firewall Settings blade, the Save button is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image63.png "Save button")

18. On the **Success!** Dialog box, click **OK**.

    ![The Success dialog box message explains that the server firewall rules were successfully updated.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image29.png "Success dialog box")

19. Close all configuration blades.

#### Subtask 2: Failover secondary SQL database -- OPTIONAL

Since the Replication and Failover process can take anywhere from 10 to 30 minutes to complete, you have the choice to skip Subtask 2 through 5, and skip directly to Task 3. However, if you have the time, it is recommended that you complete these steps.

1.  Using a new tab or instance of your browser, navigate to the Azure Management Portal <http://portal.azure.com>.

2.  In the navigation menu to the left, click **SQL databases**, and click the name of the SQL Database you created previously.

    ![Screenshot of SQL Databases tile](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image52.png "Azure Portal")

3.  On the **Settings** blade, click **Geo-Replication**.

    ![On the Settings blade, under Settings, Geo-Replication is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image64.png "Settings section")

4.  On the **Geo-Replication** blade, select the Secondary database.

    ![The Geo-Replication blade has a map of the world with locations marked on it. Under the map, Primary is set to West US, which on the map has a blue checkmark. Under Secondaries, East US is circled, and on the map displays with a green checkmark. A line connects the West Coast (blue) and East Coast (green) checkmarks.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image65.png "Geo-Replication blade")

5.  Click the **Forced Failover** button.

    ![the Forced Failover button is circled on the Secondary database blade.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image66.png "Secondary database blade")

6.  On the **Forced Failover** prompt, click **Yes**.

    ![On the East US Secondary database blade, in response to the questing asking if you are sure you want to proceed, the Yes button is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image67.png "Failover prompt")

The failover may take a few minutes to complete. You can continue with the next Subtask modifying the Web App to point to the Secondary SQL Database while the Failover is pending.

#### Subtask 3: Test e-commerce Web App after Failover

1.  Once completed, in the Azure Portal, click on **SQL databases**, and select the **ContosoSportsDB** secondary.

    ![On the SQL databases blade, under Name, the ContosoSportsDB Secondary replication role is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image68.png "SQL databases blade")

2.  Next, click on **Show database connection strings**, and copy it off thereby replacing the user and password.

    ![On the SQL database blade,on the left Overview is selected. On the right, under Essentials, the Connection strings (Show database connection strings) link is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image69.png "SQL database blade")

3.  From the Azure portal, click on **Resource Groups**, and select **contososports**.

    ![In the Azure Portal, on the left, Resource groups is circled. On the right, under Name, contososports is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image37.png "Azure Portal")

4.  Click on the **Web App** just created in a previous step.

5.  On the **App Service** blade, scroll down in the left pane, and click on **Application settings**.

    ![On the App Service blade, under Settings, Application settings is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image38.png "App Service blade")

6.  Scroll down, and locate the **Connection strings** section.

7.  Update the **ContosoSportsLeague** Connection String to the value of the **original Secondary Azure SQL Database**.

    ![On the App Service blade, in the Connection strings section, the ContosoSportsLeague connection string is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image70.png "App Service blade")

    >**Note**: Ensure you replace the string placeholder values **{your\_username}** and **{your\_password\_here}** with the username and password you respectively setup during creation (demouser AND Password.1!!).

    ![The password string placeholder value displays: Password={your\_password\_here};](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image43.png "String placeholder values")

8.  Click **Save**.

    ![On the App Service blade, the Save button is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image44.png "App Service blade Save button")

9.  On the **App Service** blade, click on **Overview**.

    ![Screenshot of Overview menu option](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image71.png "App Service blade")

10. On the **Overview** pane, click on the **URL** for the Web App to open it in a new browser tab.

    ![On the App Service blade, in the Essentials section, the URL (http;//contososportsweb4azurewebsites.net) link is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image72.png "App Service blade Essentials section")

11. After the e-commerce Web App loads in Internet Explorer, click on **STORE** in the top navigation bar of the website.

    ![On the Contoso sports league website navigation bar, the Store button is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image73.png "Contoso sports league website navigation bar")

12. Verify the product list from the database displays.

    ![Screenshot of the Contoso store webpage. Under Team Apparel, a Contoso hat, tank top, and hoodie display.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image74.png "Contoso store webpage")

#### Subtask 4: Revert Failover back to Primary database

1.  Using a new tab or instance of your browser, navigate to the Azure Management Portal <http://portal.azure.com>.

2.  In the new **SQL databases**, and click the name of the SQL Database you created previously.

    ![Screenshot of SQL Databases menu option.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image52.png "SQL Databases")

3.  On the **Settings** blade, click **Geo-Replication**.

    ![In the Settings section, Geo-Replication is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image64.png "Settings section")

4.  On the **Geo-Replication** blade, select the Secondary database.

    ![The Geo-Replication blade has a map of the world with locations marked on it. Under the map, Primary is set to East US, which on the map has a blue checkmark. Under Secondaries, West US is circled, and on the map displays with a green checkmark. A line connects the East US (blue) and West US (green) checkmarks.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image75.png "Geo-Replication blade")

5.  Click the **Forced Failover** button.

    ![The Forced Failover button in the Secondary Database blade is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image76.png "Secondary Database blade")

6.  On the **Forced Failover** prompt, click **Yes**.

    ![On the West US Secondary database blade, in response to the questing asking if you are sure you want to proceed, the Yes button is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image77.png "Failover prompt")

The failover may take a few minutes to complete. You can continue with the next Subtask modifying the Web App to point back to the Primary SQL Database while the Failover is pending.

#### Subtask 5: Test e-commerce Web App after reverting failover

1.  In the Azure Portal, click on **Resource Groups** **\>** **contososports** resource group.

    ![In the left menu of the Azure Portal, Resource groups is selected. On the right, underResource groups, contososports is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image37.png "Azure Portal")

2.  Click on the **Web App** just created in a previous step.

3.  On the **App Service** blade, scroll down in the left pane, and click on **Application settings**.

    ![In the App Service blade Settings section, Application settings is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image38.png "App Service blade")

4.  Scroll down, and locate the **Connection strings** section.

5.  Update the **ContosoSportsLeague** Connection String back to the value of the Connection String for the **original Primary SQL Database**.

    ![In the App Service blade Connection strings section, the ContosoSportsLeague connection string is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image70.png "App Service blade")

    > **Note**: Ensure you replace the string placeholder values **{your\_username}** **{your\_password\_here}** with the username and password you respectively setup during creation (demouser AND Password.1!!).

    ![The password string placeholder value displays: Password={your\_password\_here};](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image43.png "String placeholder value")

6.  Click **Save**.

    ![The Save button is circled on the App Service blade.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image44.png "App Service blade")

7.  On the **App Service** blade, click on **Overview**.

    ![Overview is selected on the App Service blade.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image71.png "App Service blade")

8.  On the **Overview** pane, click on the **URL** for the Web App to open it in a new browser tab.

    ![In the App Service blade Essentials section, the URL (http:/contososportsweb4.azurewebsites.net) link is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image72.png "App Service blade, Essentials section")

9.  After the e-commerce Web App loads in Internet Explorer, click on **STORE** in the top navigation bar of the website.

    ![On the Contoso sports league website navigation bar, the Store button is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image73.png "Contoso sports league website navigation bar")

10. Verify the product list from the database displays.

    ![Screenshot of the Contoso store webpage. Under Team Apparel, a Contoso hat, tank top, and hoodie display.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image74.png "Contoso store webpage")

### Task 3: Deploying the call center admin website

In this exercise, you will provision a website via the Azure Web App template using the Microsoft Azure Portal. You will then edit the necessary configuration files in the Starter Project and deploy the call center admin website.

#### Subtask 1: Provision the call center admin Web App 

1.  Using a new tab or instance of your browser, navigate to the Azure Management portal <http://portal.azure.com>.

2.  Click **+ Create a new resource** **\>** **Web** **\>** **Web App**. 

   ![In the left menu of the Azure Portal, the New button is selected. In middle section, under Marketplace, Web + mobile is selected. In the right, Web + mobile section, under Featured apps, Web App is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image78.png "Azure Portal")

3.  Specify a **unique URL** for the Web App, and ensure the **same App Service Plan** and **resource group** you have used throughout the lab are selected.

    ![On the Web App blade, the App name field is set to contososportsadmin2101.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image79.png "Web App blade")

4.  Click on **App Service plan/Location**, and select the **ContosoSportsPlan** used by the front-end Web App.

5.  After the values are accepted, click **Create**.

    ![Screenshot of the Create button.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image32.png "Create button")

#### Subtask 2: Update the configuration in the starter project

1.  Navigate to the **App Service** blade for the Call Center Admin App just provisioned.

    ![The App Service blade displays.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image80.png "App Service blade")

2.  On the **App Service** blade, click on **Application settings** in the left pane.

    ![In the Settings section of the App Service blade, Application settings is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image81.png "Settings section")

3.  Scroll down, and locate the **Connection strings** section.

4.  Add a new **Connection string** with the following values:

    -  Name: **ContosoSportsLeague**

    -  Value: **Enter the Connection String for the last SQL Database that was created**.

    -  Type: **SQL Database**

    ![The Connection Strings fields display the previously defined values.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image83.png "Connection Strings fields")

    >**Note**: Ensure you replace the string placeholder values **{your\_username}** **{your\_password\_here}** with the username and password you respectively setup during creation (demouser AND Password.1!!).

    ![The password string placeholder value displays: Password={your\_password\_here};](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image43.png "String placeholder values")

5.  Click **Save**.

    ![the Save button is circled on the App Service blade.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image44.png "App Service blade")

#### Subtask 3: Deploy the call center admin Web App from Visual Studio

1.  Navigate to the **Contoso.Apps.SportsLeague.Admin** project located in the **Web** folder using the **Solution Explorer** in Visual Studio.

    ![In Solution Explorer, under Solution Contoso.Apps.SportsLeague, The Web folder is expanded, and Contoso.Apps.SportsLeague.Admin is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image85.png "Solution Explorer")

2.  Right-click the **Contoso.Apps.SportsLeague.Admin** project, and click **Publish**.

    ![In Solution Explorer, the right-click menu for Contoso.Apps.SportsLeague.Admin displays, and Publish is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image86.png "Right-Click menu")

3.  Choose **Microsoft Azure App Service** as the publish target, and choose **Select Existing**.

    ![On the Publish tab, Microsoft Azure App Service is selected. Below that, the radio button is selected for Select Existing.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image87.png "Publish tab")

4.  Select the **Web App** for the Call Center Admin App.

    ![In the App Service section, in the tree view at the bottom, the contososports folder is expanded, and contososportsadmin4 is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image88.png "App Service section")

5.  Click **OK**, and click **Publish** to deploy the site.

6.  The website should load / display the following:

    ![The Contoso website displays the Contoso Sports League Admin webpage, which says that orders that display below are sorted by date, and you can click on an order to see its details. However, at this time, there is no data available under Completed Orders.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image89.png "Contoso website")

### Task 4: Deploying the payment gateway

In this exercise, the attendee will provision an Azure API app template using the Microsoft Azure Portal. The attendee will then deploy the payment gateway API to the API app.

#### Subtask 1: Provision the payment gateway API app

1.  Using a new tab or instance of your browser, navigate to the Azure Management Portal <http://portal.azure.com>.

2.  Click **+ Create a resource**, type **API App** into the marketplace search box, and press **Enter**.

    ![In the Azure Portal left menu, New is selected. In the New blade, the search field is set to API App.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image90.png "Azure Portal")

3.  On the new **API App** blade, specify a unique name for the App Name, and ensure the previously used Resource Group and App Service Plan are selected.

    ![On the API App blade, the App name field is set to PaymentsAPIO, and is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image93.png "API App blade")

4.  After the values are accepted, click **Create**.

    ![Screenshot of the Create button.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image32.png "Create button")

#### Subtask 2: Deploy the Contoso.Apps.PaymentGateway project in Visual Studio

1.  Navigate to the **Contoso.Apps.PaymentGateway** project located in the **APIs** folder using the **Solution Explorer** in Visual Studio.

    ![In Solution Explorer, under Solution Contoso.Apps.SportsLeague, the API folder is expanded, and Contoso.Apps.PaymentGateway is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image95.png "Solution Explorer")

2.  Right-click the **Contoso.Apps.PaymentGateway** project, and click **Publish**.

    ![In Solution Explorer, Contoso.Apps.PaymentGateway is selected, and in its right-click menu, Publish is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image96.png "Solution Explorer")

3.  On the **Publish Web** dialog box, click **Microsoft Azure App Service**, and choose **Select Existing**.

    ![In the Publish web dialog box, Microsoft Azure App Service is selected, as is the radio button for Select Existing.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image97.png "Publish web dialog box")

4.  Select the Payment Gateway API app created earlier, click **OK** **\>** **Publish**.

    ![In the App Service section, the contososports folder is expanded, and PaymentsAPIO is selected. ](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image98.png "App Service section")

5.  In the Visual Studio **Output** view, you will see a status indicating the Web App was published successfully.

    ![The Visual Studio output shows that the web app was published successfully. ](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image99.png "Visual Studio output")

6. Copy and paste the **URL** of the deployed **API App** for later use.

### Task 5: Deploying the offers Web API

In this exercise, the attendee will provision an Azure API app template using the Microsoft Azure Portal. The attendee will then deploy the Offers Web API.

#### Subtask 1: Provision the Offers Web API app

1.  Using a new tab or instance of your browser, navigate to the Azure Management Portal (<http://portal.azure.com>).

2.  In the navigation menu to the left, click **+ Create a resource** -\> **Web** -\> **API App**.

    ![In the Azure Portal left menu, New is selected. On the right, under New, API App is typed in the Search box.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image90.png "Azure Portal")

3.  On the new **API App** blade, specify a unique name for the **API App**, and ensure the previously used Resource Group and App Service Plan are selected.

    ![In the API App blade, OffersAPI4 is typed in the App name field.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image100.png "API App blade")

4.  After the values are accepted, click **Create**.

5.  When the Web App template has completed provisioning, open the new API App by, in the navigation menu to the left,
click **App Services** and then clicking the Offer API app you just created.

   ![In the Azure Portal, on the left More services is selected, and on the right under Web + Mobile, App Services displays.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image101.png "Azure Portal, More Services")

#### Subtask 2: Configure cross-origin resource sharing (CORS)

1.  On the **App Service** blade for the Offers API, under the **API** menu section, click **CORS**.

    ![In the App Service blade, under API, CORS is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image102.png "App Service blade")

2.  In the **ALLOWED ORIGINS** text box, specify the URL of the **e-commerce Web App** (can be found in the **Overview** link), and click **Save**.

#### Subtask 3: Update the configuration in the starter project

1.  On the **App Service** blade for the Offers API, click on **Application settings**.

    ![In the App Service blade, under Settings, Application settings is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image103.png "App Service blade")

2.  In the **Connection Strings** section, add a new **Connection string** with the following values:

    -  Name: **ContosoSportsLeague**

    -  Value: **Enter the Connection String for the SQL Database that was created**.

    -  Type: **SQL Database**

        ![The Connection strings section now has a new string with the previously defined settings.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image105.png "Connection strings section")

    >**Note**: Ensure you replace the string placeholder values **{your\_username}** **{your\_password\_here}** with the username and password you respectively setup during creation (demouser AND Password.1!!).
    
    ![The password string placeholder value displays: Password={your\_password\_here};](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image43.png "String placeholder value")

3.  Click **Save**.

    ![The Save button is selected in the App Service blade.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image106.png "Save button")

#### Subtask 4: Deploy the Contoso.Apps.SportsLeague.Offers project in Visual Studio

1.  Navigate to the **Contoso.Apps.SportsLeague.Offers** project located in the **APIs** folder using the **Solution Explorer** in Visual Studio.

    ![In Solution Explorer, under Solution Contoso.Apps.SportsLeague, the API folder is expanded, and Contoso.Apps.SportsLeague.Offer is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image107.png "Solution Explorer")

2.  Right-click the **Contoso.Apps.SportsLeague.Offers** project, and select **Publish**.

    ![In Solution Explorer, from the Contoso.Apps.SportsLeague.Admin right-click menu, Publish is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image108.png "Solution Explorer")

3.  On the **Publish Web** dialog box, click **Microsoft Azure App Service**, and choose **Select Existing**.

    ![On the Publish tab, the Microsoft Azure App Service tile is selected, and under it, the radio button for Select Existing is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image109.png "Publish tab")

4.  Select the Offers API app created earlier, and click **OK** **\>** **Publish**.

    ![In the App Service section, the contososports folder is expanded, and OffersAPI4 is selected. ](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image110.png "App Service section")

5.  In the Visual Studio **Output** view, you will see a status the API app was published successfully.

6.  Record the value of the deployed API app URL for later use.

### Task 6: Update and deploy the e-commerce website

#### Subtask 1: Update the Application Settings for the Web App that hosts the Contoso.Apps.SportsLeague.Web project

1.  Using a new tab or instance of your browser, navigate to the Azure Management Portal <http://portal.azure.com>.

2.  Click on **Resource groups** **\>** **contososports** resource group.

    ![In the Azure Portal left menu, Resource groups is selected. On the right, underResource groups, under Name, contososports is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image112.png "Azure Portal")

3.  Click on the **App Service Web App** for the front-end web application.

    ![In the Resource Group blade on the right, under Name, contososportsweb2101 is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image113.png "Resource Group blade")

4.  On the **App Service** blade, scroll down, and click on **Application settings** in the left pane.

    ![In the App Service blade, under settings, Application settings is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image103.png "App Service blade")

5.  Scroll down, and locate the **Applications settings** section.

    ![The App settings section of the App Service blade displays with AzureQueueConnectionString selected. ](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image115.png "App settings section")

6.  Add a new **Application Setting** with the following values:

    -  Key: **paymentsAPIUrl**

    -  Value: Enter the **HTTPS** URL for the Payments API App with **/api/nvp** appended to the end.

    > Example: <https://paymentsapi0.azurewebsites.net/api/nvp>

    ![In the Application settings section of the App Service blade, the previously defined application setting values are selected. ](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image116.png "App settings")

7.  Add another **Application Setting** with the following values:

    c.  Key: **offersAPIUrl**

    d.  Value: Enter the **HTTPS** URL for the Offers API App with **/api/get** appended to the end.

    > Ex: <https://offersapi4.azurewebsites.net/api/get>

    ![In the Application settings section of the App Service blade, the previously defined application setting values are selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image117.png "App settings section")

8.  Click on **Save**.

    ![The Save button is boxed in red on the App Service blade.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image44.png "App Service blade")

>**Note**: Ensure both of the API URLs are using **SSL** (https://), or you will see a CORS errors.

#### Subtask 2: Validate App Settings are correct

1.  On the **App Service** blade, click on **Overview**.

    ![Overview is selected on the left side of the App Service blade.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image119.png "App Service blade")

2.  In the **Overview** pane, click on the **URL** for the Web App to open it in a new browser tab.

    ![On the right side of the App Service blade, under Essentials, the URL (http://contososportsweb2101.azurewebsites.net) link is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image120.png "App Service blade")

3.  On the homepage, you should see the latest offers populated from the Offers API.

    ![On the Contoso Sports League webpage, Today\'s offers display: Baseball socks, Road bike, and baseball mitt.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image121.png "Contoso Sports League webpage")

4.  Submit several test orders to ensure all pieces of the site are functional.

    ![On the Contoso Sports League webpage, the message Order Completed displays.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image122.png "Contoso Sports League webpage")

>**Leader Note:** If the attendee is still experiencing CORS errors ensure the URLs to the Web App in Azure local host are exact.

## Exercise 2: Identity and security

Duration: 75 Minutes

The Contoso call center admin application will only be accessible by users of the Contoso Active Directory environment. You have been asked to create a new Azure AD Tenant and secure the application so only users from the tenant can log onT

### Task 1: Enable Azure AD Premium Trial

>**Note**: This task is **optional**, and it is valid only if you are a global administrator on the Azure AD tenant associated with your subscription.

1.  Navigate to the Azure Management portal, [http://portal.azure.com](http://portal.azure.com/), using a new tab or instance.

2.  In the left-hand navigation menu, click **Azure Active Directory**.

    ![The Azure Active Directory menu option](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image123.png "Azure Portal")

3.  On the **Azure Active Directory** blade, locate and click on the **Company branding** option.

    ![In the Azure Active Directory blade, Company branding is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image124.png "Azure Active Directory blade")

4.  In the right pane, click the **Get a free Premium trial...** link.

    ![On the left side of the Azure Active Directory blade, Company branding is selected. On the right side, the Get a free Premium trial link is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image125.png "Azure Active Directory blade")

If you already have a Premium Azure Active Directory, skip to Task 2.

5.  On the **Activate** blade, click on the **Free Trial** link within the **Azure AD Premium P2** box.

    ![The Free trial link is selected on the Activate blade in the Azure AD Premium P2 box.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image126.png "Activate blade")

6.  On the **Active Azure AD Premium P2 trial** blade, click the **Activate** button.

    ![On the Active Azure AD Premium P2 trial blade, the Activate button is boxed in red.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image127.png "Active Azure AD Premium trial blade")

7.  Close the **Azure Active Directory** blades.

### Task 2: Create a new Contoso user

>**Note**: This task is **optional**, and it is valid only if you are a global administrator on the Azure AD tenant associated with your subscription.

1.  Navigate to the Azure Management portal, [http://portal.azure.com](http://portal.azure.com/), using a new tab or instance.

2.  Click **Azure Active Directory** in the navigation menu to the left.

    ![Screenshot of Azure Active Directory menu option](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image123.png "Azure Portal")

3.  On the **Azure Active Directory** blade, click on **Custom Domain names**.

    ![Custom Domain Names menu option screenshot.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image128.png "Custom Domain names")

4.  Copy the **Domain Name** for your Azure AD Tenant. It will be in the format: *[your tenant\].onmicrosoft.com*
    This will be used for creating the new user's Username.

    ![Under Name, the Domain Name is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image129.png "Domain name")

5.  On the **Azure Active Directory** blade, click on **Users and groups** followed by **All users**.

    ![Under Manage, All users is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image130.png "Azure Active Directory blade")

6.  Click on **+ New User** to add a new user.

    ![The + New User button is boxed in red on the Azure Active Directory blade.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image131.png "Azure Active Directory blade")

7.  On the **User** blade, specify a user's **Name** and **Username**. Specify the **Username** to be at the domain name for your Azure AD Tenant. For example: *tbaker@\[your tenant\].onmicrosoft.com*.

    ![On the User blade, the two previously defined fields (Name and User name) are circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image132.png "User blade")

8.  Click on the **Show Password** checkbox, and make a note of the password for use later.

    ![The Show Password checkbox is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image133.png "Password section")

9.  Click **Create**.

    ![Screenshot of the Create button.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image134.png "Create button")

### Task 3: Configure access control for the call center administration Web Application

>**Note**: This task is **optional**, and it is valid only if you have the right to create applications in your Azure AD Tenant.

#### Subtask 1: Enable Azure AD Authentication

1.  On the left navigation of the Azure Portal, select **App Services**.

    ![Screenshot of the App Services button.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image135.png "App Services button")

2.  On the **Web Apps** page, select the **call center administration Web App**.

    ![In the App Services blade, under Name, contososportsadmin2101 is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image136.png "App Services blade")

3.  Click the **Authentication / Authorization** tile.

    ![On the App Service blade, under Settings, Authentication / Authorization is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image137.png "App Service blade")

4.  Change **App Service Authentication** to **On**, and change the dropdown to **Log in with Azure Active Directory**.

    ![The Authentication / Authorization section displays with App Service Authentication button set to On, and Log in with Azure Active Directory selected in the Action to take when request is not authenticated drop-down list box.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image138.png "Authentication / Authorization section")

5.  Click on the **Azure Active Directory**.

    ![In the Authentication Providers section, Azure Active Directory (Not Configured) is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image139.png "Authentication Providers section")

6.  On the **Azure Active Directory Settings** blade, change **Management mode** to **Express**.

    ![At the bottom of the Azure Active Directory Settings blade, Management mode is set to Express.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image140.png "Azure Active Directory Settings blade")

7.  Click **OK**.

    ![Screenshot of the OK button.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image141.png "OK button")

8.  Change the **Action to take when request is not authenticated** option to **Login with Azure Active Directory**.

    ![The Action to take when request is not authenticated field is set to Log in with Azure Authentication.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image142.png "Action to take field")

9.  In the **Authentication / Authorization** blade, click **Save**.

    ![The Save button is circled in the App Service blade.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image143.png "App Service blade")

#### Subtask 2: Verify the call center administration website uses the access control logon

1.  Close your browser (or use an alternative), and launch a browser is InPrivate or Incognito mode. Navigate to the **call center administration** website.

2.  The browser will redirect to the non-branded Access Control logon URL. You can log on with your Microsoft account or the **Contoso test user** you created earlier.

    ![Microsoft login prompt](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image144.png "Microsoft login prompt")

3.  After you log on and **accept the consent**, your browser will be redirected to the Contoso Sports League Admin webpage.

    ![The Contoso Sports League Admin webpage displays with one Completed Order.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image145.png "Contoso Sports League Admin webpage")

4.  Verify in the upper-right corner you see the link **Logged In**. If it is not configured, you will see **Sign in**.

    ![Screenshot of the Logged In message.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image146.png "Logged in message") ![Screenshot of the Sign In link.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image147.png "Sign in link")

### Task 4: Apply custom branding for the Azure Active Directory logon page

>**Note**: this task is **optional**, and it is valid only if you are a global administrator on the Azure AD tenant associated with your subscription, and you completed the Enabling Azure AD Premium exercise.

1.  Navigate to the Azure Management portal, [http://portal.azure.com](http://portal.azure.com/), using a new tab or instance.

2.  In the navigation menu to the left, select **Azure Active Directory**. 

    ![The Azure Active Directory menu option](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image123.png "Azure Active Directory")

3.  On the **Azure Active Directory** blade, click on **Company branding**.

    ![On the Azure Active Directory blade, Company branding is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image148.png "Azure Active Directory blade")

4.  Click on the **Configure...** information box.

    ![The Configure company branding link is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image149.png "Configure company branding link")

5.  On the **Configure company branding** blade, select the **default\_signin\_illustration.jpg** image file from **C:\\MCW** for the **Sign-in page image**.

    ![The Configure company branding blade displays the default sign in picture of the Contoso sports league text, and a person on a bicycle. Below that, the Select a file field and browse icon is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image150.png "Configure company branding blade")

6.  Select the **logo-60-280.png** image file from the supplementary files for the **Banner image**.

    ![The Contoso sports league banner text displays.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image151.png "Contoso sports league banner")

    Click **Save**.

    ![The Save button is circled on the Configure company branding blade.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image152.png "Configure company branding blade")

### Task 5: Verify the branding has been successfully applied to the Azure Active Directory logon page

1.  Close any previously authenticated browser sessions to the call center administration website, reopen using InPrivate or Incognito mode, and navigate to the **call center administration** website.

2.  The browser will redirect to the branded access control logon URL.

    ![The Call center administration Sign in webpage displays in an InPrivate / Incognito browser](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image153.png "Call center administration website")

3.  After you log on, your browser will be redirected to the Contoso Sports League Admin webpage.

    ![The Contoso Sports League Admin webpage displays with one completed order.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image145.png "Contoso Sports League Admin webpage")

4.  Verify in the upper-right corner you see the link **Logged in**.

    ![Screenshot of the Logged in message.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image146.png "Logged in message")

5.  If you run the app using localhost, ensure connection strings for all of the web.config files in the solution have the placeholders removed with actual values. Search on web.config in the solution explorer to come up with the list.

    ![In Solution Explorer, the following path is expanded: API\\Contoso.Apps.PaymentGateway\\Areas\\HelpPage\\Views. In the Views folder, Web.config is selected. In addition, the Web.config file is highlighted in several other folders.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image154.png "Solution Explorer")

## Exercise 3: Enable Azure B2C for customer site

Duration: 75 minutes

In this exercise, you will configure an Azure AD Business to Consumer (B2C) instance to enable authentication and policies for sign-in, sign-out and profile policies for the Contoso E-Commerce site.

### Task 1: Create a new directory

1.  Log in to the Azure portal by using your existing Azure subscription or by starting a free trial. In the left-hand navigation menu, click **+ Create a resource**. Then, search for and select **Azure Active Directory B2C** and click **Create** on the new blade that pops up. 

    ![In the Everything blade, the active directory B2C text is in the Search field, and under Results, Azure Active Directory B2C displays.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image156.png "Everything blade")

2.  In the new blade, select **Create a new Azure AD B2C Tenant**. Then, enter the name as **ContosoB2C** and a unique domain name and region. Then, click **Create**. After directory creation completes, click the link in the new information tile that reads **Click here to manage your new directory**.

    ![In the Azure Portal, under Create new B2C Tenant or Link to existing Tenant, Create a new Azure AD B2C Tenant is selected. On the right, the word \"here,\" which is a link, is circled in the Click here to manage your new directory message.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image157.png "Azure Portal")

3.  Click on the orange **No Subscription** message for instructions on how to link to an active subscription.

    ![In the Azure Portal, on the left, the \"No subscription linked to this B2C tenant or the Subscription needs your attention\" message is selected. On the right, under Subscription reminder, the three steps to link the B2C tenant to an Azure subscription are circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image158.png "Azure Portal")

>**Note**: Essentially, you will need to switch back to your previous Azure AD tenant, and then launch the Azure AD B2C creation wizard again.

4.  Click on **Link an existing Azure AD B2C Tenant to my Azure subscription,** and select the Tenant you just created in the dropdown list and the existing resource group **contososports**. Then, click **Create**.

    ![In the Create new B2C Tenant or Link to existing Tenant blade, on the left, Link an existing Azure AD B2C Tenant to my Azure subscription is selected. On the right, in the Azure AD B2C Resource blade, the Azure AD B2C Tenant drop-down field is contosob2cdemo123.onmicrosoft.com. The Resource group is using the existing contososports.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image159.png "Create new B2C Tenant or Link to existing Tenant")

5.  After creation completes, open the new Azure AD B2C tenant by clicking **Resource Groups** in the navigation menu to the left and, then, **contososports**. Then, in the new blade, click the B2C tenant you just created.

    ![In the contososports resource group, the new B2C tenant is boxed in red](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/b2ctenant_in_rg.png "Azure AD B2C Settings window")

6.  In the new blade, click the **B2C Settings** tile for the new B2C tenant. You will be taken to the new subscription for this tenant.

    ![In the Azure AD B2C tenant window, on the left, All Settings is selected. In the bottom right section, the Azure AD B2C Settings tile is selected](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image160.png "Azure AD B2C Settings window")

7. In the new tab that opened, under the **MANAGE** menu area of the open **Azure AD B2C** blade, select **Applications**. Then, in the new pane, click **+ Add**.

    ![In the Azure AD B2C Settings window, on the left, All Settings is selected. In the middle, under Settings, under Manage, Applications is selected. On the right, the Add button is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/b2c-add-app-link.png "Azure AD B2C Settings window")

### Task 2: Add a new application

1.  Specify the following configuration options for the Web App:

    -   Name: **Contoso B2C Application**

    -   Reply URL: **https://\[your web url\].azurewebsites.net \<- This should be the HTTPS URL to the Contoso E-Commerce Site**.

    -   Include Web App / web API: **Yes**

    -   Allow Implicit Flow: **Yes**

    ![The New application fields are set to the previously defined values.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image161.png "New application")

2.  Click **Create**.

3.  Back on the **Azure AD B2C** blade in the **Applications** screen, note down the application ID of your new application for use later in your code. Keep this tab open for the next task. 

     ![B2C application name and ID](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/b2c-app-listing.png "Azure AD B2C screen")

### Task 3: Create Policies, Sign up

1.  Navigate back to the **Azure AD B2C** blade that was opened in the last task.

2.  To enable sign-up on your application, you will need to create a sign-up policy. This policy describes the experiences consumers will go through during sign-up and the contents of tokens the application will receive on successful sign-ups. Click **Sign-up or sign-in policies** and then **+ Add** at the top of the blade.

    ![In the Azure Portal, on the left, under Policies, Sign-up or sign-in policies is selected. On the right, the Add button is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image162.png "Azure Portal")

3.  Enter **SignUp** in the **Name** field.

4.  Click **Identity providers**, and select **Email Signup**. Optionally, you can also select social identity providers (if previously configured for the tenant). Click **OK**.

    ![In the Add policy blade, Identity providers is selected. In the Select identity providers blade, Email signup is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image163.png "Add policy and Select identity providers blades")

5.  Click **Sign-up attributes**. Here, you choose attributes you want to collect from the consumer during sign-up. For now, select:

    - **Country/Region**
    - **Display Name**
    - **Postal Code**

    Then, click **OK**.

    ![In the Add policy blade, Sign-up attributes, with the message \"3 selected\" is selected. In the Select sign-up attributes blade, the following strings are selected: Country / Region, Display Name, and Postal Code.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image164.png "Add policy and Select sign-up attributes blades")

6.  Click **Application claims**. Here, you choose claims you want returned in the tokens sent back to your application after a successful sign-up experience. For now, select:

    - **Display Name**
    - **Identity Provider**
    - **Postal Code**
    - **User is new**
    - **User's Object ID**

    Then, click **OK**.

    ![In the Add policy blade, Application claims with the message \"5 Selected\" is selected. In the Select application claims blade, the following five strings are selected: Display Name, Identity Provider, Postal Code, User is new, and User\'s Object ID.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image165.png "Add policy and Select application claims blades")

7.  Click **Create**. Observe the policy just created appears as **B2C\_1\_SignUp** (the **B2C\_1\_** fragment is automatically added) in the **Sign-up policies** blade.

>**Note**: The page may take a few minutes to load/refresh after you start creating the policy.

8.  Open the policy by clicking **B2C\_1\_SignUp**.

![In the Policies section, Sign-in policies is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/b2csignup-listing.png "Policies section")

9.  In the new blade, select **Contoso B2C Application** in the **Select Application** drop-down.

10. Click **Run now**. A new browser tab opens, and you can run through the consumer experience of signing up for your application.

### Task 4: Create a sign-in policy

To enable sign-in on your application, you will need to create a sign-in policy. This policy describes the experiences consumers will go through during sign-in and the contents of tokens the application will receive on successful sign-ins.

1.  Click **Sign-in policies**.

    ![In the Policies section, Sign-in policies is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image166.png "Policies section")

2.  Click **+ Add** at the top of the blade.

3.  The **Name** determines the sign-in policy name used by your application. For example, enter **SignIn**.

4.  Click **Identity providers** and select **Local Account SignIn**. Optionally, you can also select social identity providers, if already configured. Click **OK**.

> ![In the Add policy blade, Identity providers with the message \"1 Selected\" is selected. In the Select identity providers blade, Local Account SignIn is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image167.png "Add policy and Select identity providers blades")

5.  Click **Application claims**. Here you choose claims that you want returned in the tokens sent back to your application after a successful sign-in experience. For now, select:

    - **Display Name**
    - **Identity Provider**
    - **Postal Code**
    - **User's Object ID**

    ![In the Add policy blade, Application claims (4 Selected) is selected. In the Select application claims blade, the following five application claims are selected: Display Name, Identity Provider, Postal Code, and User\'s Object ID.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image168.png "Add policy and Select application claims blades")

6.  Click **Create**. Observe the policy just created appears as **B2C\_1\_SignIn** (the **B2C\_1\_** fragment is automatically added) in the **Sign-in policies** blade.

7.  Open the policy by clicking **B2C\_1\_SignIn**.

8.  Select **Contoso B2C application** in the **Select Application** drop-down.

9.  Click **Run now**. A new browser tab opens, and you can run through the consumer experience of signing into your application.

### Task 5: Create a profile editing policy

To enable profile editing on your application, you will need to create a profile editing policy. This policy describes the experiences that consumers will go through during profile editing and the contents of tokens that the application will receive on successful completion.

1.  Click **Profile editing policies**.

    ![In the Policies section, Profile editing policies is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image169.png "Policies section")

2.  Click **+ Add** at the top of the blade.

3.  The Name determines the profile editing policy name used by your application. For example, enter **EditProfile**.

4.  Click Identity providers, and select \"**Local Account SignIn**." Optionally, you can also select social identity providers, if already configured. Click **OK**.

> ![In the Add policy blade, Identity providers (1 Selected) is selected. In the Select identity providers blade, Local Account SignIn is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image170.png "Add policy and Select identity providers blades")

5.  Click **Profile attributes**. Here, you choose attributes the consumer can view and edit. For now, select:

    - **Country/Region**
    - **Display Name**
    - **Job Title**
    - **Postal Code**
    - **State/Province**
    - **Street Address**

    Click **OK**.

    ![In the Add policy blade,Profile attributes (6 Selected) is selected. In the Profile attributes blade, the following six profile attributes are selected: Country / Region, Display Name, Job Title, Postal Code, State / Province, and Street Address.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image171.png "Add policy and Select identity providers blades")

6.  Click **Application claims**. Here, you choose claims you want returned in the tokens sent back to your application after a successful profile editing experience. For now, select:

    - **Display Name**
    - **Postal Code**

    Click **OK**.

7.  Click **Create**. Observe the policy just created appears as \"**B2C\_1\_EditProfile**\" (the **B2C\_1\_** fragment is automatically added) in the **Profile editing policies** blade.

8.  Open the policy by clicking **B2C\_1\_EditProfile**.

9.  Select **Contoso B2C application** in the **Select Application** drop-down.

10. Click **Run now**. A new browser tab opens, and you can run through the profile editing consumer experience in your application.

### Task 6: Modify the Contoso.App.SportsLeague.Web

1.  Within Visual Studio, open **Contoso.AppSportsLeague.sln** if it is not open already. Then, click on **View -\> Other Windows -\> Package Manager Console**. Execute the following commands to install these the required NuGet Packages.

    ```powershell
    Install-Package Microsoft.Owin.Security.OpenIdConnect -Version 3.0.1
    Install-Package Microsoft.Owin.Security.Cookies -Version 3.0.1
    Install-Package Microsoft.Owin.Host.SystemWeb -Version 3.0.1
    Install-Package Microsoft.IdentityModel.Protocol.Extensions -Version 1.0.4.403061554
    ```

2.  Next, using the Azure Management Portal, using your main subscription, open the Contoso E-Commerce Web App blade, and click on **Application Settings**.

3.  Add the following settings in the **Application Settings** section:

    -   ida:Tenant - **\[your Azure AD B2C name\].onmicrosoft.com**

    -   ida:ClientId -- **\[B2C Application ID you copied down earlier\]**

    -   ida:RedirectUri - **https://\[your web app url\].azurewebsites.net**

    -   ida:SignupPolicyId -- **B2C\_1\_SignUp**

    -   ida:SignInPolicyId -- **B2C\_1\_SignIn**

    -   ida:UserProfilePolicyId -- **B2C\_1\_EditProfile**

    -   ida:AadInstance - https://login.microsoftonline.com/{0}/v2.0/.well-known/openid-configuration?p={1}

    ![In the App settings section, the previously mentioned settings are circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image172.png "App settings ")

4.  Click **Save** when you are complete.

5.  Within Visual Studio, **right** click on the **Contoso.Apps.SportsLeague.Web** project, and click **Add -\> New Item.**

    ![In Solution Explorer, the Web folder is expanded, and Contoso.Apps.SportsLeague.Web is selected. From its right-click menu, Add is selected, and from its menu, New item is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image173.png "Solution Explorer")

6.  In the **Search Installed Templates** search box, search for **OWIN**. Click the **OWIN Startup** class, change the name to **Startup.cs**, and then click **Add**.

    ![In the New class section, the word \"partial\" is circled in the line, \"public partial class Startup\".](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/add-owin-class.png "New class section")

7.  In the new class, insert the word partial in between public and class to make this a partial class.

    ![In the New class section, the word \"partial\" is circled in the line, \"public partial class Startup\".](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image174.png "New class section")

8.  Add the following code between the brackets of the Configuration method:

    ```csharp
    ConfigureAuth(app);
    ```

    Your **Startup** class code should look like:

    ```csharp
    // Startup.cs

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
    ```

>**Note**: The OWIN middleware will invoke the Configuration(\...) method when your app starts.

9.  In the **Solution Explorer**, under **Contoso.Apps.SportsLeague.Web**, right-click on the **App\_Start** folder, and click **Add -\> Class**.

    ![In Solution Explorer, on the App Start folder\'s right-click menu, Add is selected, and from its menu, Class is selected. ](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image175.png "Solution Explorer")

10. Select **Visual C\#** category and **Class**. Name the new file **Startup.Auth.cs**.

    ![In the Installed field, Visual C\# is selected. In the Sort by field, Class is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image176.png "Installed and Sort by fields")

11. Replace the entire contents of Startup.Auth.cs with the following code:

    ```csharp
    // App_Start\Startup.Auth.cs
    using System;
    using Owin;
    using Microsoft.Owin.Security;
    using Microsoft.Owin.Security.Cookies;
    using Microsoft.Owin.Security.OpenIdConnect;
    using System.Threading.Tasks;
    using Microsoft.Owin.Security.Notifications;
    using Microsoft.IdentityModel.Protocols;

    using System.Configuration;
    using System.IdentityModel.Tokens;
    using System.Web.Helpers;
    using System.IdentityModel.Claims;

    namespace Contoso.Apps.SportsLeague.Web
    {
        public partial class Startup
        {
            // App config settings
            private static string clientId = ConfigurationManager.AppSettings["ida:ClientId"];
            private static string aadInstance = ConfigurationManager.AppSettings["ida:AadInstance"];
            private static string tenant = ConfigurationManager.AppSettings["ida:Tenant"];
            private static string redirectUri = ConfigurationManager.AppSettings["ida:RedirectUri"];

            // B2C policy identifiers
            public static string SignUpPolicyId = ConfigurationManager.AppSettings["ida:SignUpPolicyId"];
            public static string SignInPolicyId = ConfigurationManager.AppSettings["ida:SignInPolicyId"];
            public static string ProfilePolicyId = ConfigurationManager.AppSettings["ida:UserProfilePolicyId"];

            public void ConfigureAuth(IAppBuilder app)
            {
                app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

                app.UseCookieAuthentication(new CookieAuthenticationOptions());

                // Configure OpenID Connect middleware for each policy
                app.UseOpenIdConnectAuthentication(CreateOptionsFromPolicy(SignUpPolicyId));
                app.UseOpenIdConnectAuthentication(CreateOptionsFromPolicy(ProfilePolicyId));
                app.UseOpenIdConnectAuthentication(CreateOptionsFromPolicy(SignInPolicyId));
                AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
            }

            // Used for avoiding yellow-screen-of-death
            private Task AuthenticationFailed(AuthenticationFailedNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions> notification)
            {
                notification.HandleResponse();
                if (notification.Exception.Message == "access_denied")
                {
                    notification.Response.Redirect("/");
                }
                else
                {
                    notification.Response.Redirect("/Home/Error?message=" + notification.Exception.Message);
                }

                return Task.FromResult(0);
            }

            private OpenIdConnectAuthenticationOptions CreateOptionsFromPolicy(string policy)
            {
                return new OpenIdConnectAuthenticationOptions
                {
                    // For each policy, give OWIN the policy-specific metadata address, and
                    // set the authentication type to the id of the policy
                    MetadataAddress = String.Format(aadInstance, tenant, policy),
                    AuthenticationType = policy,

                    // These are standard OpenID Connect parameters, with values pulled from web.config
                    ClientId = clientId,
                    RedirectUri = redirectUri,
                    PostLogoutRedirectUri = redirectUri,
                    Notifications = new OpenIdConnectAuthenticationNotifications
                    {
                        AuthenticationFailed = AuthenticationFailed,
                    },
                    Scope = "openid",
                    ResponseType = "id_token",

                    // This piece is optional - it is used for displaying the user's name in the navigation bar.
                    TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = "name",
                    },
                };
            }
        }
    }
    ```

    > **Note**: The parameters you provide in **OpenIdConnectAuthenticationOptions** serve as coordinates for your app to communicate with Azure AD. You also need to set up cookie authentication. The OpenID Connect middleware uses cookies to maintain user sessions, among other things.

### Task 7: Send authentication requests to Azure AD

Your app is now properly configured to communicate with Azure AD B2C by using the OpenID Connect authentication protocol. OWIN has taken care of all of the details of crafting authentication messages, validating tokens from Azure AD, and maintaining user session. All that remains is to initiate each user's flow.

1.  Right click on the **Controllers** folder, and click **Add** -\> **Controller**.

    ![In Solution Explorer, in the right-click menu for the Controllers folder, Add is selected, and from its menu, Controller is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image177.png "Solution Explorer")

2.  Select **MVC 5 Controller -- Empty** amd then click **Add**. Replace **DefaultController** with **AccountController** in the **Add Controller** dialog box.

    ![On the left of the Add Scaffold window, Installed / Controller is selected. In the center of the window, MVC 5 Controller - Empty is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image178.png "Add Scaffold window")

3.  Add the following using statement to the top of the controller:

    ```csharp
    using Microsoft.Owin.Security;
    ```

4.  Replace the default controller method Index...

    ![The Default controller method Index is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image179.png "Default controller method Index")

    with the following code:

    ```csharp
    // Controllers\AccountController.cs

    public void SignIn()
    {
        if (!Request.IsAuthenticated)
        {
            // To execute a policy, you simply need to trigger an OWIN challenge.
            // You can indicate which policy to use by specifying the policy id as the AuthenticationType
            HttpContext.GetOwinContext().Authentication.Challenge(
                new AuthenticationProperties () { RedirectUri = "/" }, Startup.SignInPolicyId);
        }
    }

    public void SignUp()
    {
        if (!Request.IsAuthenticated)
        {
            HttpContext.GetOwinContext().Authentication.Challenge(
                new AuthenticationProperties() { RedirectUri = "/" }, Startup.SignUpPolicyId);
        }
    }


    public void Profile()
    {
        if (Request.IsAuthenticated)
        {
            HttpContext.GetOwinContext().Authentication.Challenge(
                new AuthenticationProperties() { RedirectUri = "/" }, Startup.ProfilePolicyId);
        }
    }

    ```

### Task 8: Display user information

When you authenticate users by using OpenID Connect, Azure AD returns an ID token to the app that contains **claims**. These are assertions about the user. You can use claims to personalize your app. You can access user claims in your controllers via the ClaimsPrincipal.Current security principal object.

1.  Open the **Controllers\\HomeController.cs** file and add the following using statements at the end of the other using statements at the top of the file.

    ```csharp
    using System.Linq;
    using System.Security.Claims;
    ```

2.  Still in the **Controllers\\HomeController.cs** file, add the following method to the **HomeController** class:

    ```csharp
    [Authorize]
    public ActionResult Claims()
    {
        Claim displayName = ClaimsPrincipal.Current.FindFirst(ClaimsPrincipal.Current.Identities.First().NameClaimType);
        ViewBag.DisplayName = displayName != null ? displayName.Value : string.Empty;
        return View();
    }
    ```

3.  You can access any claim that your application receives in the same way. A list of all the claims the app receives is available for you on the **Claims** page. Right click on **Views -\> Home,** click **Add -\> MVC 5 View Page (Razor)** and name it **Claims.** 

    ![In Solution Explorer, on the right-click menu for Views\\Home, Add is selected, and from its menu, MVC 5 View Page (Razor) is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image180.png "Solution Explorer")

4.  Open the **Claims.cshtml** file and replace the code with the following:

    ```csharp
    @using System.Security.Claims
    @{
        ViewBag.Title = "Claims";
    }
    <h2>@ViewBag.Title</h2>

    <h4>Claims Present in the Claims Identity: @ViewBag.DisplayName</h4>

    <table class="table-hover claim-table">
        <tr>
            <th class="claim-type claim-data claim-head">Claim Type</th>
            <th class="claim-data claim-head">Claim Value</th>
        </tr>

        @foreach (Claim claim in ClaimsPrincipal.Current.Claims)
        {
            <tr>
                <td class="claim-type claim-data">@claim.Type</td>
                <td class="claim-data">@claim.Value</td>
            </tr>
        }
    </table>

    ```

5.  Right click on the **Views -\> Shared** folder, click **Add**, and add a new **MVC 5 Partial Page (Razor)**. Specify **\_LoginPartial** for the name.

    ![In Solution Explorer, on the right-click menu for Views\\Shared, Add is selected, and from its menu, MVC 5 Partial Page (Razor) is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image181.png "Solution Explorer")

6.  Add the following code to the razor partial view to provide a sign-in and sign-out link as well as a link to edit the user's profile:

    ```html
    @if (Request.IsAuthenticated)
    {
        <text>
            <ul class="nav navbar-nav navbar-right">
                <li>
                    <a id="profile-link">@User.Identity.Name</a>
                    <div id="profile-options" class="nav navbar-nav navbar-right">
                        <ul class="profile-links">
                            <li class="profile-link">
                                @Html.ActionLink("Edit Profile", "Profile", "Account")
                            </li>
                        </ul>
                    </div>
                </li>
                <li>
                    @Html.ActionLink("Sign out", "SignOut", "Account")
                </li>
            </ul>
        </text>
    }
    else
    {
        <ul class="nav navbar-nav navbar-right">
            <li>@Html.ActionLink("Sign up", "SignUp", "Account", routeValues: null, htmlAttributes: new { id = "signUpLink" })</li>
            <li>@Html.ActionLink("Sign in", "SignIn", "Account", routeValues: null, htmlAttributes: new { id = "loginLink" })</li>
        </ul>
    }

    ```

7.  Open **Views\\Shared\\\_Layout.cshtml** in Visual Studio. Locate the header-top div. and add the line that starts with **@Html.ActionLink** and the line that starts with **@Html.Partial**.

    ```html
    <div class="header-top">
        <div class="container">
            <div class="row">
                <div class="header-top-left">
                <a href="#"><i class="fa fa-twitter"></i></a>
                <a href="#"><i class="fa fa-facebook"></i></a>
                <a href="#"><i class="fa fa-linkedin"></i></a>
                <a href="#"><i class="fa fa-instagram"></i></a>
                </div>
                <div class="header-top-right">
                    <a href="#" class="top-wrap"><span class="icon-phone">Call today: </span> (555) 555-8000</a>
                    @Html.ActionLink("Claims", "Claims", "Home")               
                </div>                   
                @Html.Partial("_LoginPartial")
            </div>
        </div>
    </div>
    ```

### Task 9: Run the sample app

1.  Right click on the **Contoso.Apps.SportsLeague.Web** project, and click **Publish**. Follow the steps to deploy the updated application to the Microsoft Azure Web App.

    Launch a browser outside of Visual Studio for testing if the page loads in Visual Studio.

2.  Test out Sign up. Next, test Sign out.

3.  When you click on Claims and are not signed in, it will bring you to the sign-in page and then display the claim information. Sign in, and test Edit Profile.

    ![On the Contoso website, the following links are circled: Claims, Sign up, and Sign in.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image182.png "Contoso website")

    Claims information page![On the Contoso website, the following links are circled: Russell, Sign out, and Edit Profile.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image183.png "Contoso website, Claims information page")

## Exercise 4: Enabling Telemetry with Application Insights 

To configure the application for logging and diagnostics, you have been asked to configure Microsoft Azure Application Insights and add some custom telemetry.

>**Note**: You may need to create an Application Insights Resource in Azure portal depending on your subscription rights. After it is created, you can configure it and add to the project using the tasks below. To create a new Application Insights resource.

1.  Click **Create** a resource. **Search** the marketplace for Application Insights. **Select** Application Insights.

    ![In this screenshot a new application insights instance is created using the Azure portal.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image184.png "Screenshot of creating a resource")

2.  Click the **Create** button.

    ![A screenshot that provides an overview of Application Insights and a button to click Create.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image185.png "Application insights resource")

3. Enter the name as **Contoso.Apps.SportsLeague.Web.** Choose the existing resource group of **contososports**. Location should be the same location as your resource group.

    ![A dialog that shows the properties of the application insights resource](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image186.png "Application insights creation dialog")

### Task 1: Configure the application for telemetry

#### Subtask 1: Add Application Insights Telemetry to the e-commerce website project

1.  Open the Solution **Contoso.Apps.SportsLeague** in Visual Studio.

2.  Navigate to the **Contoso.Apps.SportsLeague.Web** project located in the **Web** folder using the **Solution Explorer** in Visual Studio.

    ![In Solution Explorer, the Web folder is expanded, and Contoso.Apps.SportsLeague.Web is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image187.png "Solution Explorer")

3.  Right-click the **Contoso.Apps.SportsLeague.Web** project, and select **Add \| Application Insights Telemetry..**.

    ![In Solution Explorer, on the Web folder\'s right-click menu, Add is selected, and from its menu, Application Insight Telemetry is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image188.png "Solution Explorer")

4.  Expand the **Sending telemetry to** section.

    ![On the Application Insights tab, under Resource Settings, the expand arrow is circled for the Sending telemetry to section.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image189.png "Application Insights tab")

5.  Click on the **Configure settings...** link.

    ![In the Sending telemetry to section, the link to Configure settings is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image190.png "Sending telemetry to section")

6.  In the **Application Insights Configuration** dialog box, change the **Resource Group** to the **contososports** resource group used to host the Web App, and choose the New Application Insights Resource. Next, click **OK**, followed by **Update Resource**.

    ![In the Application Insights Configuration dialog box, the Resource Group contososports is selected. In the Application Insights Resource drop-down list box, Contoso.Apps.SportsLeague.Web is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image191.png "Application Insights Configuration dialog box")

7.  Press **Finish** on the Application Insights window.

    ![The Finish button is circled in the Application Insights window.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image192.png "Application Insights window")

8.  Once it completes, it displays the following Output and opens a new browser window:

    ![Screenshot of Output.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image193.png "Output")

9.  Open the file **\\Helpers\\TelemetryHelper.cs** located in the **Contoso.Apps.SportsLeague.Web** project.

10. Add the following using statement to the top of the file:

    ```csharp
    using Microsoft.ApplicationInsights;
    ```

11. Add the following code to the **TrackException** method to instantiate the telemetry client and track exceptions:

    ```csharp
    var client = new TelemetryClient();
    client.TrackException(new Microsoft.ApplicationInsights.DataContracts.ExceptionTelemetry(exc));
    ```

12. Add the following code to the **TrackEvent** method to instantiate the telemetry client and track event data:

    ```csharp
    var client = new TelemetryClient();
    client.TrackEvent(eventName, properties);
    ```

13. Save the **TelemetryHelper.cs** file.

#### Subtask 2: Enable client side telemetry

1.  Open the Azure Management Portal (<http://portal.azure.com>). In the navigation menu to the left, click **All Services**. Filter by **Application Insights** and then select the appropriate result.

    ![On the left of the Azure Portal, All services is selected. On the right, Application Insights is in the search box and the result is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image194.png "Azure Portal")

2.  Click the Application Insights instance associated with the Contoso E-Commerce Site.

    ![Under Name, Contoso.Apps.SportsLeague.Web displays.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image195.png "Name section")

3.  In CONFIGURE menu click on **Getting Started**.

    ![From the Configure menu, Getting started is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image196.png "Configure menu")

4.  Next, click the **MONITOR AND DIAGNOSE CLIENT SIDE APPLICATION** arrow. This will open the **Client application monitoring and diagnosis** blade.

    ![Screenshot of the MONITOR AND DIAGNOSE CLIENT SIDE APPLICATION arrow.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image197.png "MONITOR AND DIAGNOSE CLIENT SIDE APPLICATION ")

5.  Select and copy the full contents of the JavaScript on the **Client application monitoring and diagnosis** blade.

    ![Under Guidance in the Client application monitoring and diagnosis blade, JavaScript displays. ](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image198.png "Client application monitoring and diagnosis blade")

6.  Navigate to the **Contoso.Apps.SportsLeague.Web** project located in the **Web** folder using the **Solution Explorer** in Visual Studio.

7.  Open **Views \> Shared \> \_Layout.cshtml**.

    ![In Solution Explorer, under Views\\Shared, Layout.cshtml is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image199.png "Solution Explorer")

8.  Paste in the code before the **\</head\>** tag.

    ![In Layout.cshtml, code displays, and several lines are selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image200.png "Layout.cshtml tab")

9.  Save the **\_Layout.cshtml** file.

#### Subtask 3: Deploy the e-commerce Web App from Visual Studio

1.  Navigate to the **Contoso.Apps.SportsLeague.Web** project located in the **Web** folder using the **Solution Explorer** in Visual Studio.

    ![In Solution Explorer, under the Web folder, Contoso.Apps.SportsLeague.Web is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image201.png "Solution Explorer")

2.  Right-click the **Contoso.Apps.SportsLeague.Web** project, and select **Publish**.

    ![From the Contoso.Apps.SportsLeague.Web right-click menu, Publish is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image202.png "Solution Explorer")

3.  Click **Publish** again when the Publish dialog appears.

    Launch a browser **outside of Visual Studio** for testing if the page is loaded in Visual Studio.

4.  Click a few links on the published E-Commerce website, and submit several orders to generate some sample telemetry.

### Task 2: Creating the web performance test and load test

#### Subtask 1: Create the load test

1.  Open the Azure Management Portal (<http://portal.azure.com>). In the navigation menu to the left, click **All Services**. Filter by **Application Insights** and then select the appropriate result.

    ![On the left of the Azure Portal, All services is selected. On the right, Application Insights is in the search box and the result is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image194.png "Azure Portal")

2.  Click the Application Insights instance associated with the Contoso E-Commerce Site.

    ![In the Name section, Contoso.Apps.SportsLeague.Web is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image204.png "Name section")

3.  Click **Performance Testing**.

    ![On the Configure menu, Performance Testing is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image205.png "Configure menu")

4.  Click the **Set Organization** button to associate/create an Azure DevOps account.

    ![On the Application Insights blade, Set Organization is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image206.png "Application Insights blade")

5.  On the Organization Settings tile, click **Or Create New**.

    ![On the Organization Settings tile, the Or Create New link is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image207.png "Account tile")

6.  Specify a unique name for the account and select a region. Note the region may differ from the region you have deployed your resources.

    ![On the Organization Settings blade, under Azure DevOps Account, contososportsis selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image208.png "Account Settings blade")

7.  Click **Subscription**, and select **your Subscription**.

    ![The Subscription option displays.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image209.png "Subscription option")

8.  Click **Select location**. Next, select a Location.

    ![The Select location option displays.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image210.png "Select location option ")

    > **Note**: The location tile may disappear after setting your Subscription.

9.  Then, click **OK**.

    > **Note**: The Azure DevOps account creation will take a minute to complete.

10. Click **New**.

    ![On the Application Insights blade, the New button is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image211.png "Application Insights blade")

11. Click on **Configure Test Using**.

    ![The Configure Test Using option displays.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image212.png "Configure Test Using option")

12. Specify the **URL** to the Contoso E-Commerce site, and click **Done**.

    ![In the Configure test using blade, the https://contososportsweb3.azurewebsites URL is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image213.png "Configure test using")

13. Name the test **ContosoSportsTest**, and click the **Run test** button.

    ![On the New performance test blade, under Name, ContosoSportsTest is selected. At the bottom, the Run test button is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image214.png "New performance test blade")

14. Wait until the load test has completed.

    ![In the Recent runs section, the load test for ContosoSportsTest has a state of Completed.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image215.png "Recent runs section")

#### Subtask 2: View the Application Insights logs

1.  Using a new tab or instance of your browser, navigate to the Azure Management portal <http://portal.azure.com>.

2.  On the left menu area, click **All services**.

3.  On the **All Services** blade, filter for **Application Insights** and choose the appropriate result.

4.  On the **Application Insights** blade, select the Application Insights configuration you created for the e-commerce website.

    ![The Application Insights configuration option Contoso.Apps.SportsLeague.Web is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image216.png "Application Insights configuration option")

5.  View the performance timeline to see the overall number of requests and page load time.

    >**Note**: If necessary, click the informational tile at the top to go to the new Overview experience.

    ![The Health graph displays the performance overview timeline of overall requests and response times.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image217.png "Health graph")

6.  Under **USAGE (PREVIEW)** menu area. click the **Events** menu option. Then, click one of the bars in the bar chart in the lower part of the screen. 

    ![A screenshot using the Events button under the Usage Preview section](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image218.png "The Usage Preview section")

7.  After several minutes, you should see several custom events from your previous order testing. This is reported through the TelemetryClient's TrackEvent method.

    >**Note**: If you do not see data here, come back later after the lab is complete.

    ![In the Custom events section, OrderCompleted is 3, and SuccessfulPaymentAuth is 3.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image219.png "Custom events section")

## Exercise 5: Automating backend processes with Azure Functions and Logic Apps

Contoso wants to automate the process of generating receipts in PDF format and alerting users when their orders have been processed using Azure Logic App and Functions. To run custom snippets of C\# or node.js in logic apps, you can create custom functions through Azure Functions. [Azure Functions](https://docs.microsoft.com/en-us/azure/azure-functions/functions-overview) offers server-free computing in Microsoft Azure and are useful for performing these tasks:

-   Advanced formatting or compute of fields in logic apps

-   Perform calculations in a workflow.

-   Extend the logic app functionality with functions that are supported in C\# or node.js

### Task 1: Create an Azure Function to Generate PDF Receipts

1.  Click the **+ Create a resource** button found on the upper left-hand corner of the Azure portal and then click **Compute \> Function App**. Then in the new blade, select your Subscription, type an unique App name that identifies your function app, then specify the following settings:

    -   [**Resource Group**](https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-group-overview): Use the existing resource group **contososports**.

    -   [**Hosting plan**](https://docs.microsoft.com/en-us/azure/app-service/azure-web-sites-web-hosting-plans-in-depth-overview), which can be one of these plans:

        -   **Hosting plan**: The default hosting plan type for Azure Functions is **Consumption Plan**. When you choose a consumption plan, you must also choose the **Location**. For now, select **App Service Plan**. 

        -   **App Service plan**: An App Service plan requires you to create an **App Service plan/location** or select an existing one. These settings determine the [location, features, cost, and compute resources](https://azure.microsoft.com/pricing/details/app-service/) associated with your app. For now, select the existing App Service Plan you have been using so far in this lab. 

        -   **Storage account**: Each function app requires a storage account. Choose the existing storage account by clicking Select Existing and choosing the storage account in the contososports resource group.

    ![On the left side of the Portal, the Create a resource button is selected. In the middle, under New, Compute is selected. On the right, under Compute, Function App is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image221.png "Azure Portal")

2.  Click **Create** to provision and deploy the new function app.

    ![Under Function App, the App name field is set to ContosoFunctionApp, and at the bottom the Create button is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image222.png "Function App section")

3.  Open the Function App you just created. Click the **+** besides **Functions**, scroll down, and select **Custom function**.

    ![In Function Apps, on the left side, the plus sign shown when hovering over Function is selected. On the right side, the Custom Function link is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image223.png "Function Apps")

4.  In the **GenericWebHook** card, click the **C#** link.

    ![In the Azure Portal, under Choose a template below, the GenericWebHook-CSharp tile is selected. Below, the Name your function field is ContosoMakePDF, and the Create button is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image224.png "Azure Portal")

5.  In the **New Function** blade, name the function **ContosoMakePDF** and then click **Create**.

    ![In the New Function blade, settings are consistent with instructions.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image225.png "View files expand arrow")

6.  Expand the **View files** area on the right of the code window and then click **Upload**.

    ![Screenshot of the Upload button.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/function-view-files.png "Upload button")

    ![Screenshot of the Upload button.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image226.png "Upload button")

7.  Upload the following files in the (Contoso Sports League\\Contoso.CreatePDFReport) folder beneath: C:\\MCW.

    -   ViewModels.csx
    -   CreatePdfReport.csx
    -   run.csx
    -   sample.dat
    -   StorageMethods.csx
    -   Project.json

    ![The previously mentioned files display.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image227.png "Files")

8.  Click on **run.csx**, to refresh the code editor.

    ![In the Code Editor, on the right, run.csx is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image228.png "Code Editor")

9.  Expand the **Log** pane on the bottom.

    ![The arrow button besides the Logs tab is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image229.png "Logs window")

    >**Note**: You should see several messages about downloading dependent assemblies such as the Azure SDK and iText Sharp that were defined in the project.json file.

10. Select the name of your function app, and then click on **Platform Features** followed by **Application settings.**

    ![In the Azure Portal, under Function Apps, ContosoFunctionApp is selected. Under General Settings, Application settings is selected. The Platform Features link is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image230.png "Azure Portal")

10. In the **Application Settings**, add a new entry called **contososportsstorage**, and paste the value of the connection string noted in an earlier exercise. Click **Save** after adding the value.

    ![In the Application settings section, contososportsstorage and its value are selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image231.png "App settings section")

    >**Note**: You can find the value by opening the storage account, and clicking the **Access Keys** tile.

11. Back in your function, open the **sample.dat** file, and select as well as copy (Ctrl+C) the test data.

    ![The Sample.dat file displays.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image232.png "Sample.dat file")

12. Select the **Run.csx** file, click on the **Test** tab, and replace the contents by pasting (CTRL-V) in the Test tab Request Body. Ensure that there are no parameters.

    ![Screenshot of the run.csx file, and the Test tab request body.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image233.png "Run.csx file, Test tab request body")

13. Select the **View Files** tab, select **Run.csx**, and click run.

14. You should see messages in the Logs window stating the Webhook was triggered, and the PDF was generated / saving it the storage account. Also, you should see that actual message text in the Output Window.

    ![In the run.csx file, under Logs, messages stating the Webhook was triggered and the PDF was generated are circled. In the Test tab request body, under Output, the message text is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image234.png "Run.csx file, Test tab request body")

15. To see that the PDF indeed landed in the receipts container in blob storage, download **Microsoft Storage Explorer** at [http://storageexplorer.com](http://storageexplorer.com/). Use Microsoft Storage Explorer to verify the PDF landed on the Blob Container for receipts. You may need to refresh and/or select another folder, and arrive back to the receipts folder to see the PDF.

    ![In Storage Explorer, on the left, the following path is expanded: Storage Accounts\\contososportsstorage01\\Blub containers. Under Blob Containers, receipts is circled. On the right, on the receipts tab, ContosoSportsLeague-Store-Receipts-38.pdf is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image235.png "Storage Explorer")

### Task 2: Create an Azure Logic App to Process Orders

Without writing any code, you can automate business processes more easily and quickly when you create and run workflows with Azure Logic Apps. Logic Apps provide a way to simplify and implement scalable integrations and workflows in the cloud. It provides a visual designer to model and automate your process as a series of steps known as a workflow. There are [many connectors](https://docs.microsoft.com/en-us/azure/connectors/apis-list) across the cloud and on-premises to quickly integrate across services and protocols.

The advantages of using Logic Apps include the following:

-   Saving time by designing complex processes using easy to understand design tools.

-   Implementing patterns and workflows seamlessly, that would otherwise be difficult to implement in code.

-   Getting started quickly from templates.

-   Customizing your logic app with your own custom APIs, code, and actions.

-   Connect and synchronize disparate systems across on-premises and the cloud.

-   Build off of BizTalk server, API Management, Azure Functions, and Azure Service Bus with first-class integration support.

1.  Next, we will create a Logic App that will trigger when an item is added to the **receiptgenerator** queue. In the Azure Management Portal, click the **+** button, search for **Logic App**, click the returned Logic App result, and click **Create**.

    ![In the Azure Portal, under Marketplace, Everything is selected. Under Everything, Logic App is in the search field. Under Name, Logic App is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image236.png "Azure Portal")

2.  Fill out the name as **ContosoLogicApplication** along with your subscription, and use the existing resource group **contososports**. Choose the **same region** as your Web App and storage account. Click **Create**.

    ![In the Create logic app blade, ContosoLogicApplication is in the Name field. Under Resource group, the Use existing radio button is selected, and contososports is the name.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image237.png "Create logic app blade")

3.  Open up the logic app after it is deployed by clicking **All Services**, searching for and selecting **Logic App** and selecting the Logic App you just created.

    ![In the Azure Portal, logic is in the search field, and under that, Logic apps is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image238.png "Azure Portal")

4.  Click on the **Logic App Designer** link.

    ![In the Logic app blade, under Development tools, Logic App Designer is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image239.png "Logic app blade")

5.  In the Logic Apps Designer, under **Templates**, select **Blank Logic App**.

    ![In the Logic Apps Designer, the Blank Logic App tile is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image240.png "Logic Apps Designer")

6.  Select **Azure Queues.**

    ![In the Services section, the Azure Queues tile is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image241.png "Services section")

7.  Select **Azure Queues -- When there are messages in a queue**.

    ![In the Search all triggers section, Azure Queues - When there are messages in a queue is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image242.png "Search all triggers section")

8.  Specify **ContosoStorage** as the connection name, select the Contoso storage account from the list, and click **Create**.

    ![In When there are messages in a queue, the Connection Name is ContosoStorage, and under Storage Account, contosostorage123321 is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image243.png "When there are messages in a queue ")

9.  Select the **receiptgenerator** queue from the drop-down, click **New Step**, and **Add an Action**.

    ![Under When there are messages in a queue, the Queue name is set to receiptgenerator. At the bottom, the New Step and Add an action buttons are selected. ](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image244.png "Queue name")

10. Select **Azure Functions**.

    ![In the Choose an action section, under Services ,the Azure Functions tile is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image245.png "Choose an action")

11. Click the **Azure Function App** you just created.

    ![Under Azure Functions, on the Actions tab, a single Action, the Azure function contosofunction2101, is listed.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image246.png "Azure Functions")

12. Click the Azure function **ContosoMakePDF**.

    ![Under Azure Functions, on the Actions tab, a single Action, the Azure function contosofunction2101, is listed.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image247.png "Azure Functions")

13. Type this in the Request Body:

    ```json
    {"Order": pick MessageText from list on right }
    ```

    Make sure the syntax is json format. Sometimes the ":" will go to the right side of MessageText by mistake. Keep it on the left. It should look like this:

    ![Under ContosoMakePDF, the previous JSON code is typed in the Request Body, and to the right of this, in Insert parameters from previous steps, Message text is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image248.png "ContosoMakePDF")

14. Click **Save** to save the Logic App.

15. There is one modification we need to make in the code. Click on the **CodeView** button.

    ![In the Logic App, the CodeView button is selected from the top menu.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image250.png "Logic App")

16. Find the line of code in the body for the Order item that reads the MessageText value from the queue, and add the base64 function around it to ensure it encoded before passing it off to the Azure function. It should look like the following:

    ```json
    "Order": "@{base64(triggerBody()?['MessageText'])}"
    ```

    ![In the Order item code, the following line of code is circled: \"Order\": \"@{base64(triggerBody()?\[\'MessageText\'\])}\"](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image251.png "Order item code")

    Click **Save** again.

17. Run the logic app. It should process the orders you have submitted previously to test PDF generation. Using Azure Storage Explorer or Visual Studio Cloud Explorer you can navigate to the storage account and open the receipts container to see the created PDFs.

    ![In Azure Storage Explorer, on the left, the following tree view is expanded: Storage Accounts\\contososportsstorage01r\\Blob Containers. Under Blob Containers, receipts is selected. On the right, the ContosoSportsLeague-Store-Receipt-72.pdf is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image252.png "Azure Storage Explorer")

18. Double click it to see the Purchase receipt.

19. Now, click the **Designer** button in the Logic Apps Designer screen. add two more steps to the flow for updating the database and removing the message from the queue after it has been processed. Switch back to the designer, click **+ New Step** and select **Add an Action**.

    ![In Designer, the New Step link is circled. Under New step, the Add an action tile is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image254.png "Designer")

20. Select **SQL Server**.

    ![In the Services section, under Services, SQL Server is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image255.png "Services section")

21. Select **SQL Server - Update row**.

    ![In the SQL Server section, on the Actions tab, SQL Server - Update row is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image256.png "SQL Server section")

22. Name the connection ContosoSportsDB, and select the primary ContosoSportsDB database for your solution. Under the user name and password used to create it, click **Create.**

    ![TheUpdate row section displays the previously defined settings.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image257.png "Update row")

23. From the drop-down select the name of the table, **Orders**.

    ![In the Update row section, under Table name, Orders is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image258.png "Update row section")

24. Press **Save** and ignore the error. Click the **Code View** button.

25. Replace these lines:

    ![Screenshot of code to be replaced.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image259.png "Code view")

    With these:

    ```json
    "OrderDate": "@{body('ContosoMakePDF')['OrderDate']}",
    "FirstName": "@{body('ContosoMakePDF')['FirstName']}",
    "LastName": "@{body('ContosoMakePDF')['LastName']}",
    "Address": "@{body('ContosoMakePDF')['Address']}",
    "City": "@{body('ContosoMakePDF')['City']}",
    "State": "@{body('ContosoMakePDF')['State']}",
    "PostalCode": "@{body('ContosoMakePDF')['PostalCode']}",
    "Country": "@{body('ContosoMakePDF')['Country']}",
    "Phone": "@{body('ContosoMakePDF')['Phone']}",
    "SMSOptIn": "@{body('ContosoMakePDF')['SMSOptIn']}",
    "SMSStatus": "@{body('ContosoMakePDF')['SMSStatus']}",
    "Email": "@{body('ContosoMakePDF')['Email']}",
    "ReceiptUrl": "@{body('ContosoMakePDF')['ReceiptUrl']}",
    "Total": "@{body('ContosoMakePDF')['Total']}",
    "PaymentTransactionId": "@{body('ContosoMakePDF')['PaymentTransactionId']}",
    "HasBeenShipped": "@{body('ContosoMakePDF')['HasBeenShipped']}"
    ```

26. And modify the path variable to include the index key or OrderId to be as follows:

    ```json
    "path": "/datasets/default/tables/@{encodeURIComponent(encodeURIComponent('[dbo].[Orders]'))}/items/@{encodeURIComponent(encodeURIComponent(body('ContosoMakePDF')['OrderId']))}"
    ```

    The code should now look as follows for the update\_row method:

    ![Screenshot of replacement code.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image260.png "Code")

27. **Save** and return to the designer.

28. Your updated designer view should look like this:

    ![The Update row section displays the purchase fields.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image261.png "Update row section")

29. Finally, let us add one more step to remove the message from the queue. Press **+New Step** and **Add an Action**. Type in Queue in the search box, and select Azure Queues -- Delete message.

    ![In the Choose an action section, queue is typed in the search field. Under Services, Azure Queues is selected. On the Actions tab, Azure Queues - Delete message is selected. ](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image262.png "Choose an action section")

30. Select the **receiptgenerator** queue from the list.

31. Select **Message Id** **\>** **Pop Receipt** from the list, and click **Save**.

    ![In the Update row section, on the left in the Delete message fields, Message ID and Pop receipt are selected. On the right, under When there are messages in a queue, Message ID and Pop receipt are selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image263.png "Update row section")

32. Click Run on the Logic App Desinger, and then run the Contoso sports Web App and check out an Item.

33. Run the admin website app, and select the last Details link in the list.\
    ![Screenshot of the Details link.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image264.png "Details link")

34. You should now see a Download receipt link because the database has been updated.

    ![In the Order Details window, the Download receipt link is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image265.png "Order Details window")

35. Click on the Download receipt link to see the receipt.

36. Return to the Logic app and you should see all green check marks for each step. If not, click the yellow status icon to find out details.

    ![In the Logic app, all steps have green checkmarks.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image267.png "Logic app")

### Task 3: Use Twilio to send SMS Order Notifications

#### Subtask 1: Configure your Twilio trial account

1.  If you do not have a Twilio account, sign up for one for free at the following URL:

    [**https://www.twilio.com/try-twilio**](https://www.twilio.com/try-twilio).

    ![Screenshot of the Twilio account Sign up for free webpage.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image268.png "Twilio account Sign up webpage")

2.  When you sign up for a free Twilio trial, you will be asked to verify your personal phone number. This is an important security step that is mandatory for trying Twilio.

    ![On the Verification prompt, the \"We need to verify you\'re a human\" message displays. Under that is a phone number field, and a Verify via SMS button.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image269.png "Verification prompt")

3.  Give your a project a name.

    ![Screenshot of Twilio project name screen.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/twilio-project-name.png "Twilio Project Name Screen")

4.  Click **All Products & Services**.

    ![In the Console, under Home, the All Products and Services (ellipses) button is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image270.png "Console")

5.  Click on **Phone Numbers**.

    ![On the Console, under Numbers, Phone Numbers is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image271.png "Console")

6.  Click **Get Started**.

    ![On the Console, under Phone Nunbers, the Get Started button is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image272.png "Console")

7.  Click the **Get your first Twilio phone number** button.

    ![On the Get Started with Phone Numbers prompt, the Get your first Twilio phone number button displays.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image273.png "Get Started with Phone Numbers prompt")

8.  Record the **Phone Number**, click the **Choose this Number** button on the **Your first Twilio Phone Number** prompt, and click **Done.**

    ![On the Your first Twilio Phone Number prompt, the number is obscured.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image274.png "Your first Twilio Phone Number prompt")

9.  Click on **Home**, then **Settings**. Authenticate if needed and then record the **Account SID** and **Auth Token** for use when configuring the Twilio Connector.

    ![On the Console, on the left, the Home button and the Settings menu tab are selected. On the right, under API Credentials, Account SID and Auth Token are circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image275.png "Console")

#### Subtask 2: Create a new logic app 

1.  Open **SQL Server Management Studio** and connect to the SQL Database for the **ContosoSportsDB** database.

    ![In Object Explorer, ContosoSportsDBserver1234.database is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image276.png "Object Explorer")

2.  Under the **ContosoSportsDB** database, expand **Programmability**, right-click on **Stored Procedures**, click **New**, followed by **Stored Procedure...**

    ![In Object Explorer, the following path is expanded: ContosoSportsDBserver1234.database\\Databases\\ContosoSportsDB\\Programmability\\Stored Procedures. From the right-click menu for the Stored Procedures, New / Stored Procedure is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image277.png "Object Explorer")

3.  Replace the Stored Procedure Template code with the following:

    ```sql
    CREATE PROCEDURE [dbo].[GetUnprocessedOrders]
    AS
    declare @returnCode int 
    SELECT @returnCode = COUNT(*) FROM [dbo].[Orders] WHERE PaymentTransactionId is not null AND PaymentTransactionId <> '' AND Phone is not null AND Phone <> '' AND SMSOptIn = '1' AND SMSStatus is null
    return @returnCode

    GO
    ```

4.  Click on **Execute** in the toolbar, or press the F5 key.

    ![Screenshot of the Execute button.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image278.png "Execute button")

5.  Delete the SQL script for the Stored Procedure from the code editor, and replace it with the following:

    ```sql
    CREATE PROCEDURE [dbo].[ProcessOrders]
    AS
    SELECT * FROM [dbo].[Orders] WHERE PaymentTransactionId is not null AND PaymentTransactionId <> '' AND Phone is not null AND Phone <> '' AND SMSOptIn = '1' AND SMSStatus is null;

    UPDATE [dbo].[Orders] SET SMSStatus = 'sent' WHERE PaymentTransactionId is not null AND PaymentTransactionId <> '' AND Phone is not null AND Phone <> '' AND SMSOptIn = '1' AND SMSStatus is null;
    ```

6.  Click on **Execute** in the toolbar, or press the F5 key.

    ![Screenshot of the Execute button.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image278.png "Execute button")

7.  In the Azure Management Portal, click the **+ Create a resource** button, then **Web**, and, finally **Logic App**.

    ![In the Azure Portal, on the left side, the Create a resource menu option is selected. On the right, Web and Logic App are selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image279.png "Azure Portal")

8.  On the **Create logic app** blade, assign a value for **Name**, and set the Resource Group to **contososports**.

    ![In the Create logic app blade, the Name field is set to contososportssms. Under Resource group, Use existing is selected, and contososports is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image280.png "Create logic app blade")

9.  In the navigation menu to the left in the Portal, click **Resource Groups** then **contososports**, then the new Logic App you just created. 

10. In the Logic App blade, under the **DEVELOPMENT TOOLS** menu area, click **Logic App Designer**. Then, sselect the **Blank Logic App** Template.

    ![In the Logic Apps Designer, the Blank Logic App tile is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image282.png "Logic Apps Designer")

11. On the **Logic Apps Designer**, click **Schedule**. Then, click **Schedule - Recurrence**. 

    ![In the Logic Apps Designer, the Schedule tile is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image283.png "Logic Apps Designer")

12. Set the **FREQUENCY** to **MINUTE**, and **INTERVAL** to 1.

    ![Under Recurrence, the Frequency field is Minute, and the Interval field is 1.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image284.png "Recurrence section")

13. Click the **New Step** button followed by **Add an action**.

    ![The New step button and Add an action buttons are selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image285.png "Recurrence section")

14. Type **SQL Server** into the filter box, and click the SQL **Server -- Execute stored procedure** action.

    ![Under Choose an action, sql server is typed in the search field. On the Actions tab, SQL Server (Execute stored procedure) is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image286.png "Choose an action section")

15. The first time you add a SQL action, you will be prompted for the connection information. Name the connection **ContosoDB**, input the server and database details used earlier, and click **Create**.

    ![In the SQL Server - Execute stored procedure section, the Connection Name is contosoDB. Server and database details are the same as used earlier.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image287.png "SQL Server - Execute stored procedure section")

16. Select the **\[dbo\].\[GetUnprocessedOrders\]** stored procedure from the drop-down on the Procedure Name field.

    ![In the Execute stored procedure section, the Procedure name is \[dbo\].\[GetUnprocessedOrders\].](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image288.png "Execute stored procedure section")

17. Click on **New Step**, and click the **Add a condition** link.

    ![The New step and Add a condition buttons are selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image289.png "Buttons")

18. Specify **ReturnCode** for the OBJECT NAME, set the RELATIONSHIP to **is greater than**, and set the VALUE to **0**.

    ![Under Condition, Object Name is ReturnCode, Relationship is is greater than, and Value is 0.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image290.png "Condition section")

19. Click the **Add an action** link on the **If true** condition.

    ![Under If true, the Add an action button is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image291.png "If yes section")

20. Click **SQL Server**, and then click the **SQL Server -- Execute stored procedure** action.

    ![Under If Yes, SQL Server - Execute stored procedure is circled.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image292.png "If yes section")

21. Select the **ProcessOrders** stored procedure in the Procedure name dropdown.

    ![Under If Yes, Execute stored procedure 2 is selected, and the Procedure name is \[dbo\].\[ProcessOrders\].](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image293.png "If yes section")

22. Click the **Add an action** link.

    ![The Add an action button is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image294.png "Add an action button")

23. Type **Twilio** in the filter box, and click the **Twilio -- Send Text Message (SMS)** connector.

    ![Under Show Microsoft managed APIs, the Search box is set to Twilio, and below, Twilio - Send Text Message (SMS) is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image295.png "Show Microsoft managed APIs")

24. Set the Connection Name to Twilio, specify your Twilio **Account SID** and **Authentication Token**, then click the **Create** button.

    ![In the Twilio - Send Text Message (SMS) section, fields are set to the previously defined settings.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image296.png "Twilio - Send Text Message (SMS)")

25. Using the drop-down, select your Twilio number for the **FROM PHONE NUMBER** field. Specify a place holder phone number in the **TO PHONE NUMBER**, and a **TEXT** message.

    ![Under Send Text Message (SMS), the From Phone Number and To Phone Number fields are circled, and in the Text field is the message, Hello, your order has shipped!](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image297.png "Send Text Message (SMS)")

26. On the Logic App toolbar, click the **Code View** button.

    ![The code view button is selected on the Logic App toolbar.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image298.png "Logic App toolbar")

27. Find the **Send\_Text\_Message\_(SMS)** action, and modify the body property of the Twilio action:

    ![The Code view displays the text message, and the from and to phone numbers.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image299.png "Code view")

    Add the following code between Hello and the comma:

    ```json
    "@{item()['FirstName']}"
    ```

    ![The Code view now displays the added code in the text message.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image300.png "Code view")

28. Modify the **to** property to pull the phone number from the item.

    ```json
    "to": "@{item()['Phone']}"
    ```

    ![The to phone number code now displays the updated line of code.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image301.png "Code view")

29. Immediately before the **Send\_Text\_Message\_(SMS)** section, create a new line, and add the following code:

    ```json
    "forEach_email": {
        "type": "Foreach",
        "foreach": "@body('Execute_stored_procedure_2')['ResultSets']['Table1']",
        "actions": {
    ```

30. Remove the **runAfter** block from the **Send\_Text\_Message\_(SMS)** action.

    ![The runAfter block of code displays.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image302.png "Code view")

31. Locate the closing bracket of the **Send\_Text\_Message\_(SMS)** action, create a new line after it (be **SURE** to place a leading comma after the closing bracket), and add the following code:

    ```json
         },
    "runAfter": {
        "Execute_stored_procedure_2": [
            "Succeeded"
        ]
    }
}
    ```

33. Click **Save** on the toolbar to enable the logic app.

    ![On the Logic Apps Designer toolbar, the Save button is selected.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image304.png "Logic Apps Designer toolbar")

33. After the code for the **Send\_Text\_Message\_(SMS)** has been modified to be contained within the **forEach\_email** action and you save it, it should look like the following:

    ![The Code view displays the code from \"Foreach\" to \"Execute stored procedure.\"](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image303.png "Code view") 

34. Your workflow should look like below, and you should receive a text for each order you have placed.

    ![The Workflow diagram begins with Recurrence, then flows to Execute stored procedure, then to Condition. The Condition fields are as follows: Object Name, ReturnCode; Relationship, is greater than; Value, 0. Below the Workflow diagram is an If Yes box, with a workflow that begins wtih Execute stored procedure 2, and flows to forEach email. There is also an If No, Do Nothing box.](images/Hands-onlabstep-by-step-Moderncloudappsimages/media/image305.png "Workflow diagram")

## After the hands-on lab

Duration: 10 minutes

### Task 1: Delete resources

1.  Since the HOL is now complete, go ahead and delete all of the Resource Groups that were created for this HOL. You will no longer need those resources and it will be beneficial to clean up your Azure Subscription.

You should follow all steps provided *after* attending the hands-on lab.