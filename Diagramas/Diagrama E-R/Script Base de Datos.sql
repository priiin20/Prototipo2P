create database db_2parcial;
use db_2parcial;

create table if not exists CLIENTE(
	pk_id_cliente int(10)not null auto_increment,
    nombre_cliente varchar(40)not null,
    apellido_cliente varchar(100)not null,
    nit_cliente varchar(10)not null,
    telefono_cliente int(1)not null,
    primary key(pk_id_cliente),
    key(pk_id_cliente)
);

create table if not exists VENTAS_ENCABEZADO(
	pk_encabezado_venta int(10)not null ,
    fk_id_cliente int(10)not null,
    fecha_venta Date,
    Total_Venta Float(1)not null,
    estatus_venta varchar(1) not null,
    primary key(pk_encabezado_venta , fk_id_cliente),
    key(pk_encabezado_venta , fk_id_cliente)
);


create table if not exists VENTAS_DETALLE (
	fk_encabezado_venta int(10)not null ,
    fk_id_producto int(10)not null ,
    cantidad_vendida float(10,2)not null,
    costo_vendida float(10,2)not null,
    precio_vendida float(10,2)not null,
    primary key(fk_encabezado_venta, fk_id_producto),
    key(fk_encabezado_venta, fk_id_producto)
);


create table if not exists PRODUCTO(
	pk_id_producto int(10)not null ,
    nombre_producto varchar(100)not null,
    descripcion_producto varchar(100)not null,
    cantidad_producto int(10)not null,
    estado_reporte_aplicativo int(1)not null,
    primary key(pk_id_producto),
    key(pk_id_producto)
);


alter table VENTAS_ENCABEZADO add constraint fk_venta_cliente foreign key(fk_id_cliente) references CLIENTE(pk_id_cliente);

alter table VENTAS_DETALLE  add constraint fk_enca_deta foreign key(fk_encabezado_venta) references VENTAS_ENCABEZADO(pk_encabezado_venta);
alter table VENTAS_DETALLE  add constraint fk_deta_producto foreign key(fk_id_producto) references PRODUCTO(pk_id_producto);


/* insertar datos*/
insert into CLIENTE (nombre_cliente, apellido_cliente, nit_cliente, telefono_cliente) values("karen","Roldan","254873-k",55647258);
insert into CLIENTE (nombre_cliente, apellido_cliente, nit_cliente, telefono_cliente) values("Maria","Perez","254854-l",5458258);

select * from CLIENTE
