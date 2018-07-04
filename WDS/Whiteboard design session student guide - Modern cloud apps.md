![](https://github.com/Microsoft/MCW-Template-Cloud-Workshop/raw/master/Media/ms-cloud-workshop.png "Microsoft Cloud Workshops")

<div class="MCWHeader1">
Modern cloud apps
</div>

<div class="MCWHeader2">
 Whiteboard design session student guide
</div>

<div class="MCWHeader3">
March 2018
</div>


Information in this document, including URL and other Internet Web site references, is subject to change without notice. Unless otherwise noted, the example companies, organizations, products, domain names, e-mail addresses, logos, people, places, and events depicted herein are fictitious, and no association with any real company, organization, product, domain name, e-mail address, logo, person, place or event is intended or should be inferred. Complying with all applicable copyright laws is the responsibility of the user. Without limiting the rights under copyright, no part of this document may be reproduced, stored in or introduced into a retrieval system, or transmitted in any form or by any means (electronic, mechanical, photocopying, recording, or otherwise), or for any purpose, without the express written permission of Microsoft Corporation.

Microsoft may have patents, patent applications, trademarks, copyrights, or other intellectual property rights covering subject matter in this document. Except as expressly provided in any written license agreement from Microsoft, the furnishing of this document does not give you any license to these patents, trademarks, copyrights, or other intellectual property.

The names of manufacturers, products, or URLs are provided for informational purposes only and Microsoft makes no representations and warranties, either expressed, implied, or statutory, regarding these manufacturers or the use of the products with any Microsoft technologies. The inclusion of a manufacturer or product does not imply endorsement of Microsoft of the manufacturer or product. Links may be provided to third party sites. Such sites are not under the control of Microsoft and Microsoft is not responsible for the contents of any linked site or any link contained in a linked site, or any changes or updates to such sites. Microsoft is not responsible for webcasting or any other form of transmission received from any linked site. Microsoft is providing these links to you only as a convenience, and the inclusion of any link does not imply endorsement of Microsoft of the site or the products contained therein.
© 2018 Microsoft Corporation. All rights reserved.

Microsoft and the trademarks listed at https://www.microsoft.com/en-us/legal/intellectualproperty/Trademarks/Usage/General.aspx are trademarks of the Microsoft group of companies. All other trademarks are property of their respective owners.

**Contents**

<!-- TOC -->

- [Modern cloud apps whiteboard design session student guide](#modern-cloud-apps-whiteboard-design-session-student-guide)
    - [Abstract and learning objectives](#abstract-and-learning-objectives)
    - [Step 1: Review the customer case study](#step-1-review-the-customer-case-study)
        - [Customer situation](#customer-situation)
        - [Customer needs](#customer-needs)
        - [Customer objections](#customer-objections)
        - [Infographic for common scenarios](#infographic-for-common-scenarios)
    - [Step 2: Design a proof of concept solution](#step-2-design-a-proof-of-concept-solution)
    - [Step 3: Present the solution](#step-3-present-the-solution)
    - [Wrap-up](#wrap-up)
    - [Additional references](#additional-references)

<!-- /TOC -->

#  Modern cloud apps whiteboard design session student guide

## Abstract and learning objectives 

In this Microsoft Cloud Workshop, attendees will implement an end-to-end solution for e-commerce that is based on Azure App Services, Azure Active Directory, and Visual Studio Online. Attendees will ensure the solution is PCI-compliant, and appropriate security measures are put into place for both on-premises and public access scenarios.

Attendees will be better able to deploy and configure Azure Web Apps and associated services. In addition,

-   Configure Web Apps for authentication with Azure AD

-   Instrument and load-test the application with App Insights

-   Automate back end services using Logic Apps

## Step 1: Review the customer case study 

**Outcome** 

Analyze your customer’s needs.

Timeframe: 15 minutes 

Directions: With all participants in the session, the facilitator/SME presents an overview of the customer case study along with technical tips. 

1.  Meet your table participants and trainer 
2.  Read all of the directions for steps 1–3 in the student guide 
3.  As a table team, review the following customer case study
 
### Customer situation

The Contoso Sports League Association (CSLA) is one of the largest sports franchises. They have over 100 championships in their history and a huge, passionate fan base. They run a highly successful e-commerce website that sells merchandise to their legions of sports fans. The website is built using ASP.NET and currently hosted in a co-location.

They accept payment by credit card and owing to their high annual volume (in the tens of millions, processing about 50K per day) of transactions, need to ensure that they are Payment Card Industry Data Security Standards (PCI DSS) Level 1 compliant. Their website hosts the shopping cart and checkout process, but they defer the credit card authorization and capture responsibilities of the credit card processing to a third-party payment gateway. This payment gateway provides a web application programming interface (API) that is invoked over Transport Layer Security (TLS) from Contoso server-side logic. The call includes the credit card holder data (name, number, and so on) and returns a status indicating a success or failure in authorizing and capturing payment against the credit card. It is called after the customer clicks checkout, as a part of processing the order. They currently store their customer and profile data in SQL Server 2014.

In addition to the public facing e-commerce website, they have a backend website that supports their call center. Call center employees use this admin website to view customer orders. Customers can call in to the call center to place orders and pay for orders with their credit cards by phone.

CSLA manages the order fulfillment process. When an order arrives, they store the order details in their SQL database, and send a message for each order to their inventory management system running the warehouse. CSLA experiences a roughly 12-hour window that spans east to west coast business hours, during which they get most of their orders. The warehouse receives the message (which simply contains the order ID from the database), pulls up the order details identified in the message (by a lookup against the database), and then for each item in the order queues up a separate process to locate the item in inventory or place an order for it with their supplier. Once this initial status for each item in the order is collected, the inventory status is updated in the database and a confirmation email is sent to the customer indicating the estimated delivery date of their completed order (and if any items are in backorder). This inventory lookup rarely takes more than a few hours and never more than a day.

They have reached a point where managing their server infrastructure is becoming a real challenge and are interested in understanding more about platform as a service (PaaS) solutions that could help them focus their efforts more on the core business value rather than infrastructure. They have observed that Azure has received PCI compliance certification, and are interested in moving their solution to Azure. "We're finding that with every upgrade, we're spending more and more engineering time on infrastructure and less on the experience that matters most to our fan base," says Francisco Martinez, Chief Executive Officer (CEO) of Contoso Sports League Association, "we need to rebalance those efforts."

One example is in how they manage the usernames and passwords for call center operators and support staff, as applied to the call center admin website. Today they have a homegrown solution that stores usernames and passwords in the same database used for storing merchandise information. They have experimented with other third-party solutions in the past, and their employees found it jarring to see another company's logo displayed when logging into their own call center website. In creating their identity solution, they want to ensure they can brand the login screens with their own logo. Additionally, Contoso is concerned about hackers from foreign countries/regions gaining access to the administrator site. Before they choose an identity solution, they would like to see how it indicates such attempts.

There is one architectural enhancement Contoso would like to make in the transition to a PaaS solution. When a visitor loads the home page, it gets the list of featured products on offer (consisting of the product image, title, and URL) from the Offers service. The home page does it using a client-side GET request against an ASP.NET Web API 2 service that is executed as the page loads in the browser. Contoso anticipates growing the functionality of this service and would like to scale it independently of the website.

Contoso is also looking to augment their data analytics story by introducing a data warehouse to enable them to analyze their historical data over time, particularly as their number of transactions soars in the cloud. They would like to plan for a solution that moves the data from their OLTP database into their data warehouse on a nightly basis, ideally with the minimum amount of infrastructure or development effort. 

### Customer needs 

1.  Maintain existing PCI compliance

2.  Ensure data privacy and protection across all aspects of the system, in transit and at rest

3.  Make architectural decisions that help to minimize engineering around infrastructure in favor of those that deliver core business value

4.  Ensure that they retain their core functionality, even if the way it is accomplished under the covers might change

5.  Provide a better solution for the management of usernames and passwords

6.  Provide a regional database failover plan that will enable the customer to initiate the failover to another region, allowing their various web applications and other hosted services to roll over to a synchronized database at minimal cost

7.  A data warehouse for analyzing their transaction history

### Customer objections 

1.  It is not clear to us from the Azure Trust Center just how Azure helps our solution become PCI compliant.

2.  Can we provide a solution that scales to meet our public demand, but is also secure for use by our call center and warehouse?

3.  Our PCI compliance requires us to have a quarterly audit and to conduct occasional penetration tests. Is it supported by Azure?

4.  Can we audit the Azure data center?

5.  In the past, we have relied on SOASTA CloudTest to design and execute our web load tests at scale. In moving to Azure, are we still take advantage of CloudTest?

6.  Our previous infrastructure did not have great performance monitoring of our websites. What options would you recommend we investigate that would work with our web apps in Azure?

7.  We have heard that Azure's data warehouse can be paused? Does that mean we have to store all our data in Azure Storage first before we can pause the instances and risk losing our data? 

### Infographic for common scenarios

![This diagram is of a Common scenario for an E-Commerce Website. The diagram begins with an end user, includes a services tier, internet tier, and data tier, and ends at an Enterprise. The diagram also includes Microsoft Azure, and Azure Virtual Network.](images/Whiteboarddesignsessiontrainerguide-Moderncloudappsimages/media/image2.png "Common scenario for an E-Commerce Website")

## Step 2: Design a proof of concept solution

**Outcome** 
Design a solution and prepare to present the solution to the target customer audience in a 15-minute chalk-talk format. 

Timeframe: 60 minutes

**Business needs**

Directions: With all participants at your table, answer the following questions and list the answers on a flip chart. 
1.  Who should you present this solution to? Who is your target customer audience? Who are the decision makers? 
2.  What customer business needs do you need to address with your solution?

**Design** 
Directions: With all participants at your table, respond to the following questions on a flip chart.


*High-level architecture*

1.  Without getting into the details, (the following sections will address the details), diagram your initial vision for handling the top-level requirements for the e-commerce website, call center website, and inventory lookup process. You will refine this diagram as you proceed.

*Order fulfillment*

1.  How would you recommend CSLA manage the inventory lookup queues? How would you help CSLA decide between Azure Queues and Service Bus? Be sure to consider details implied by CSLA's requirements such as volume, message lifetime, and sizing. Explain the details of any computations you make.

*Notifications*

1.  How would you recommend CSLA manage notifying customers as their order in the CSLA orders database is processed? Are there specific Azure services that can be used? Include details on how this would be implemented and integrated into the proposed solution for CSLA.

*Offers service*

1.  Would you propose Contoso use the Azure App Service API app to meet their requirements for the Offers service?

2.  If so, what specific configurations would you need to make to support your proposed topology?

3.  Specifically, how would you implement the changes and configurations required to allow for inter-app communication between the e-commerce application and the Offers service?

*Geo-resiliency*

1.  How would you implement high availability for the orders database to guard against regional data center outages? Be specific on how you would configure SQL Database and Azure Storage.

2.  What mechanisms would you provide to the customer to initiate a failover in the event of an outage, ensuring their web applications and associated Azure services change over to a secondary region?

3.  How long would a failover take and how much data could be lost, in terms of time?

*Access control*

1.  With respect to managing access to the call center website, explain how you would recommend Contoso implement a solution that meets their requirements. Be specific about both the implementation and the process you would use to gain Contoso's acceptance of the proposed solution.

*Enabling PCI compliance*

1.  Keeping only the e-commerce website and handling of cardholder data in scope for PCI, consider the following in your design:

    a.  Are web apps deployed in Azure App Service Environments an option?

    -   Explain how using Azure App Service Environments could address the PCI requirements.

    -   Keeping in mind the best choice for securing inbound and outbound traffic for an App Service Environment, detail all inbound and outbound traffic for this solution that allows it to be PCI compliant and allows it to operate within Azure. It should include traffic into and out of the solution, outbound for the e-commerce website, and any other traffic between the apps within the solution.

    -   Make sure to describe in detail the network topology you are using.

    -   For any inbound and outbound application communications you are securing, please detail the specific mechanisms you will use to do so.

    -   If your approach includes configuration scripts, please provide an example of the scripts.

    -   Would you recommend they use Azure virtual machines? Why or why not?

*Data warehouse*

1.  How would you recommend Contoso implement their data warehouse?

2.  How would Contoso schedule nightly data transfers from their OLTP database to their data warehouse?

*Access control*

1.  How would you recommend Contoso implement their data warehouse?

2.  How would Contoso schedule nightly data transfers from their OLTP database to their data warehouse?

**Prepare**

Directions: With all participants at your table: 

1.  Identify any customer needs that are not addressed with the proposed solution
2.  Identify the benefits of your solution.
3.  Determine how you will respond to the customer’s objections.

Prepare a 15-minute chalk-talk style presentation to the customer. 

## Step 3: Present the solution

**Outcome**
 
Present a solution to the target customer audience in a 15-minute chalk-talk format.

Timeframe: 30 minutes

**Presentation** 

Directions:
1.  Pair with another table
2.  One table is the Microsoft team and the other table is the customer
3.  The Microsoft team presents their proposed solution to the customer
4.  The customer makes one of the objections from the list of objections
5.  The Microsoft team responds to the objection
6.  The customer team gives feedback to the Microsoft team.
7.  Tables switch roles and repeat Steps 2–6


##  Wrap-up 

Time frame: 15 minutes

Directions: Tables reconvene with the larger group to hear the facilitator/SME share the preferred solution for the case study.

##  Additional references

|    |            |
|----------|:-------------:|
| **Description** | **Links** |
| Compliance Commitments | <http://azure.microsoft.com/en-us/support/trust-center/services/> |
| Azure App Services | <https://azure.microsoft.com/en-us/documentation/articles/app-service-value-prop-what-is/> |
| Azure Service Environment | <https://azure.microsoft.com/en-us/documentation/articles/app-service-app-service-environment-intro/> |
| Azure Trust Center | <http://azure.microsoft.com/en-us/support/trust-center/> |
| Azure PCI Attestation of Compliance | <http://download.microsoft.com/download/7/1/E/71E02A19-D1A4-448F-8CEA-D6A19398ABDA/Azure%20PCI%20AOC%20Feb%202015.pdf> |
| PCI DSS v3.0 | <https://www.pcisecuritystandards.org/documents/PCI_DSS_v3.pdf> |
| Azure Data Factory | <https://azure.microsoft.com/en-us/documentation/articles/data-factory-data-movement-activities/#data-factory-copy-wizard/> |
| Azure SQL Database | <https://docs.microsoft.com/en-us/azure/sql-database/sql-database-geo-replication-overview/> |
