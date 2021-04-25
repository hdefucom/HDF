#this is HDF's first repositories.

#Study is a learning materials folder.

Git远程仓库（github/gitee）ssh和https推送方式的区别

1.当本地计算机git用户配置邮箱为正常格式（xxxx@xx.com）时，并且该邮箱为账号绑定的邮箱，无论使用ssh还是https推送，最终github/gitee提交记录虽然会记录在自己账户下，但是提交记录详情里，用户显示的是没有头像并且链接为tomail:xxxx@xx.com，不可直接链接到用户在线页面。
2.当本地计算机git用户配置邮箱为网站格式（123456+namespace@user.noreply.[github/gitee].com）时，那么推送后github/gitee提交记录里用户显示的就是网站账号的头像，并且可链接到用户在线页面。

由此可得，推送记录里，推送用户实质上是由git config user.email决定的，只有使用的是网站格式邮箱，推送记录里面才能显示网站用户，否则全部是显示离线用户。