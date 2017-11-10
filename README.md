# Zapier integration module
Zapier integration module exposes APIs for data synchronization with <a href="https://zapier.com" target="_blank">Zapier</a>.

Integration with Zapier allows VirtoCommerce solution to interchange data with outside systems through Zapier. The "New Customer" and "New Order" zapier triggers are currently available. That allows passing information about customers and orders to 3rd-party systems. A "New Customer" zapier action is also available, so that new customers can be imported automatically from the 3rd-party systems using Zapier Zap. In the future releases we plan to add more triggers and actions on demand.


# Installation
Installing the module:
* Automatically: in VC Manager go to Configuration -> Modules -> Zapier integration -> Install
* Manually: download module zip package from https://github.com/VirtoCommerce/vc-module-zapier/releases. In VC Manager go to Configuration -> Modules -> Advanced -> upload module package -> Install.

Installing VirtoCommerce App on Zapier:
* Use this link to connect to VirtoCommerce App: https://zapier.com/developer/invite/20161/98b8a9209c0fdb0452411b3165c2a42f/. Once connected, you'll be ready to create ZAPs with VirtoCommerce. Check this demo on how the contacts in VirtoCommerce are synched with <a href="http://mailchimp.com" target="_blank">MailChimp</a>'s mailing list:

[![VirtoCommerce integration in zapier](https://cloud.githubusercontent.com/assets/5801549/17244818/6dacdeb0-558c-11e6-8582-f8c4bb189bb8.png)](https://www.youtube.com/watch?v=2TORKsoj5Bw)

Details to pay attention:
* VirtoCommerce Portal url should be entered without "http://" or "https://" prefix (e.g., demo.virtocommerce.com/admin)
* API Key should be a simple API key generated for a VirtoCommerce user having a "security:call_api" permission. 

# Settings
This module has no settings defined as all integration actions are initiated from Zapier.

# License
Copyright (c) Virto Solutions LTD.  All rights reserved.

Licensed under the Virto Commerce Open Software License (the "License"); you
may not use this file except in compliance with the License. You may
obtain a copy of the License at

http://virtocommerce.com/opensourcelicense

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
implied.
