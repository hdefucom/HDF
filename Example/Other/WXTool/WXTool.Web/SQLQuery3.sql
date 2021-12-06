

select * from users

select * from roles

select * from menus


--insert into roles(rolecode,rolename) values('admim','管理员')
--insert into roles(rolecode,rolename) values('user','普通用户')
--insert into roles(rolecode,rolename) values('vip','贵宾用户')

--insert into menus(MenuCode,MenuName) values('index','首页')
--insert into menus(MenuCode,MenuName) values('magage','管理')
--insert into menus(MenuCode,MenuName) values('vip','贵宾')

--insert into menus(MenuCode,MenuName,ParentId) values('wx','微信','2')
--insert into menus(MenuCode,MenuName,ParentId) values('vipindex','贵宾首页','3')

----管理员五个菜单
--insert into RoleMenus(RoleId,MenuId) values(1,1)
--insert into RoleMenus(RoleId,MenuId) values(1,2)
--insert into RoleMenus(RoleId,MenuId) values(1,3)
--insert into RoleMenus(RoleId,MenuId) values(1,4)
--insert into RoleMenus(RoleId,MenuId) values(1,5)
----普通用户一个菜单
--insert into RoleMenus(RoleId,MenuId) values(2,1)
----贵宾用户三个菜单
--insert into RoleMenus(RoleId,MenuId) values(3,1)
--insert into RoleMenus(RoleId,MenuId) values(3,3)
--insert into RoleMenus(RoleId,MenuId) values(3,4)


--insert into UserRoles(UserId,RoleId) values(1,1)
--insert into UserRoles(UserId,RoleId) values(1,2)
--insert into UserRoles(UserId,RoleId) values(1,3)

--insert into UserRoles(UserId,RoleId) values(2,1)
--insert into UserRoles(UserId,RoleId) values(2,2)
--insert into UserRoles(UserId,RoleId) values(2,3)




select distinct
u.UserCode,u.UserName ,
--ur.RoleId,
--rm.MenuId,
m.MenuCode,m.MenuName
from users u
left join UserRoles ur on ur.UserId=u.UserId
left join RoleMenus rm on rm.RoleId=ur.RoleId
left join Menus m on m.MenuId=rm.MenuId
where u.UserCode='hdf'






select 

r.RoleCode,r.RoleName ,
rm.MenuId

from Roles r

left join RoleMenus rm on r.RoleId=rm.RoleId

where r.RoleName='管理员'

































