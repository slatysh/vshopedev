# vshopedev
Vshope is a service for converting Vkontakte group products to Avito xml.

This is just example of code. So some private information in files was deleted.
Main repo is private and exists on microsoft team services.

Dev version of service runned on azure web services: http://vshopedev.azurewebsites.net/home
To login by test company use this credentials:

Login: test@test.test

Password: test123

Web service runned on free tier, and for db used local azure mySql db functionallity - so there may be some perfomance issues.
Especially on first request.

To get avito xml - go to VK functionality, run refresh of products.
Then go to avito functionality - and request xml file.
Then you can upload avito xml to avito throuh theirs avito xml func.

Other functionality - is in dev for now. 

Ou and for work with vk used vkAuth, so it will ask you allow some permissions on work with vk functionallity. (Information about group products may be getted only with user auth).

Thx for your attention)
