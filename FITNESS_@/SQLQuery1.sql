create database defense_project

 create table coach (
 cid int primary key identity,
cname varchar(50) ,
cgender varchar(20) ,
cdob date,
cphone varchar(20),
speciality varchar(50),
cpass varchar(25)
 )

 create table membership (
 mid int primary key identity,
 mname varchar(20),
 mduration int ,
 mcoast money )

 create table reception (
 rid int primary key identity,
 rname varchar(50),
 rgender varchar(20) ,
 rdob date,
 rphone varchar(20),
 rpass varchar(25) )

 create table customer (
  u_id  int primary key identity,
  uname varchar(50),
  ugender varchar(20) ,
  udob date,
  uphone varchar(20),
  umembership int,
  utiming varchar(20),
  ucoach int,
  ustatus varchar(20)
  constraint fk1 foreign key(umembership) references membership(mid),
   constraint fk2 foreign key(ucoach) references coach(cid)
  )



  create table billing (
  bid int primary key identity,
  agent int ,
  member int,
  bperiod varchar(50),
  bdate datetime,
  bamount money 
  constraint fk3 foreign key(agent) references reception(rid),
   constraint fk4 foreign key(member) references customer(u_id) 
  )
