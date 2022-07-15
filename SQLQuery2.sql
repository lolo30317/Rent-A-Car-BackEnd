
alter table Users add constraint pk_IdKolonu_solo primary key (Id)

Alter table Customers add constraint fk_UserID_Referance foreign key(UserId) references Users(Id)

