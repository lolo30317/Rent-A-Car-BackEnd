insert into Brands values (1,'Mercedes'),(2,'BMW'),(3,'Audi'),(4,'Citroen'),(5,'Honda'),(6,'Ford'),
(7,'Fiat'),(8,'Opel'),(9,'Ferrari'),(10,'Toyota');

insert into Colors values (1,'Beyaz'),(2,'Gri'),(3,'Siyah'),(4,'Kırmızı'),(5,'Koyu Gri'),(6,'Açık Gri'),
(7,'Mavi'),(8,'Lacivert'),(9,'Yeşil'),(10,'Füme');

alter table Brands add constraint u_BrandId_unique_tableBrand unique(BrandId);
alter table Colors add constraint u_ColorId_unique_tableColor unique(ColorId);

alter table Cars add constraint fk_BrandId_reference foreign key(BrandId) references Brands(BrandId);
alter table Cars add constraint fk_ColorId_reference foreign key(ColorId) references Colors(ColorId);


insert into Cars values (1,1,2018,320,'White Mercedes c220'),(2,4,2014,320,'Red BMW i320'),(7,7,2021,320,'Blue Fiat egea');