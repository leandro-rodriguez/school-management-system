import React from "react";
import './NavBar.css';
import 'antd/dist/antd.css';
import Logo from "../NavBar/images/Logo.jpg"
import Help from "../NavBar/images/Help.jpg"
import Account from "../NavBar/images/Account.jpg"
import Notifications from "../NavBar/images/Notification.jpg"
import Logout from "../NavBar/images/Logout.png"
import {Dropdown, Menu, Space} from "antd";
import {DownOutlined} from "@ant-design/icons";
import { Button, Drawer, List, Alert } from 'antd';
import { useState,  useEffect } from 'react';
import axios from 'axios';
import Faq from 'react-faq-component'

import { Badge } from 'antd';

const NavBar = (props) => {
    
    const [visibleFAQ, setVisibleFAQ] = useState(false);
    const [visibleNoti, setVisibleNoti] = useState(false);
    const [data, setData] = useState([])
    const [rows, setRowsOption] = useState(null)
    const config = {
        animate: true,
        openOnload: 0,
    };
    const faq = {
        title: "",
        rows: [
          {
            title: "Sección Personal",
            content: "En la sección Personal tendrá acceso a los datos de los estudiantes y trabajadores del centro"
          },
          {
            title: "Sección Ofertas",
            content: "En la sección de Ofertas encontrará los horarios de clases de cada grupo en la sede,así como la información de estos cursos"
          },
          {
            title: "Sección Finanzas",
            content: "Esta sección muestra los ingresos y gastos que ha tenido la sede. Permite registrar el pago de los salarios de los trabajadores, por cada grupo en el que imparte sus clases. Permite registrar los cobros de los cursos pendientes de cada estudiante, así como reconocer a los deudores (aquellos alumnos que tienen pagos atrasados)."
          },
          {
            title: "Sección Administración",
            content: "En esta sección el adminitrador podrá gestionar la cuenta de los usuarios que tengan acceso al sitio, y definir sus roles. Permite la modificación de cargos que puede tener un trabajador. Además perimite la gestión de los medios básicos y las aulas del centro."
          },          
          {
            title: "Cómo añadir un dato de una tabla?",
            content: "Diríjase a la Sección donde se encuentren los datos que desea añadir. Una vez dentro de esta ventana, arriba de la tabla a la derecha encontrará el icono de +. Al seleccionarlo, se le mostrará un formulario en el que debe introducir los datos que desea almacenar, en su formato correspondiente. Si su información es válida, puede seleccionar el botón ACEPTAR para registrar la información. Si en lugar de esto, no quiere agregar el nuevo dato, seleccione CANCELAR"
          },
          {
            title: "Cómo eliminar un dato de una tabla?",
            content: "Diríjase a la Sección donde se encuentren los datos que desea eliminar. Una vez dentro de esta ventana, busque en la tabla el registro que desea eliminar, y posiciónece en la columna Eliminar. Luego seleccione el botón que se le muestra y confirme la eliminación del dato, marcando ACEPTAR."
          },
          {
            title: "Cómo eliminar varios datos de una tabla?",
            content: "Diríjase a la Sección donde se encuentren los datos que desea eliminar. Una vez dentro de esta ventana, seleccione en las casillas a la izquierda de la tabla, de los elementos que desea eliminar. Una vez marcadas, presione el boton - de la parte superior derecha de la tabla. Luego seleccione el botón que se le muestra y confirme la eliminación de los datos, marcando ACEPTAR."
          },
          {
            title: "Cómo editar un dato de una tabla?",
            content: "Diríjase a la Sección donde se encuentren los datos que desea editar. Una vez dentro de esta ventana, busque en la tabla el registro que desea editar, y posiciónece en la columna Editar. Luego seleccione el botón que se le muestra. Ahora podrá editar los datos de esa fila. Para guardar dichos datos, selecciones el icono del disquete y confirme la edición. Si quiere cancelar esto, seleccione el icono de +."
          },
          {
            title: "Cómo buscar un dato de una tabla?",
            content: "Diríjase a la Sección donde se encuentren los datos que desea editar. Una vez dentro de esta ventana, introduzca en la caja de texto BUSCAR, situada arriba a la derecha de la tabla, el dato que desea buscar. Tenga en cuenta que la búsqueda se hace celda por celda de cada fila de la tabla."
          }
        ]        
      };

    const showDrawerFAQ = () => {
        setVisibleFAQ(true);
    };

    const onCloseFAQ = () => {
        setVisibleFAQ(false);
    };

    const showDrawerNoti = () => {
        setVisibleNoti(true);
    };

    const onCloseNoti = () => {
        setVisibleNoti(false);
    };

    const getData = async () => 
        await axios.get("http://localhost:5145/api/DebtorsNotification")
            .then(resp=>{ 
                setData([resp.data]);
            });

    const menu = (
        <Menu
            items={[
                {
                    label: <p>{localStorage["username"]}</p>,                    
                    key: '0',
                },
                {
                    label: <a href="http://localhost:8080/" onClick={() => localStorage.clear()}>Cerrar sesión</a>,
                    key: '1',
                },
            ]}
        />
    );

    useEffect(()=>{
        getData();
        if (rows) {
            setTimeout(() => {
                rows[0].expand();
            }, 2500);

            setTimeout(() => {
                rows[0].close();
            }, 5000);

            setTimeout(() => {
                rows[0].scrollIntoView();
                // rows[0].scrollIntoView(true);
            }, 10000);
        }        
    },[rows]);

    //const data = [
    //    {
    //      title: 'Título de Notificación 1',
    //      description: 'Descripción 1'
    //    },
    //    {
    //        title: 'Título de Notificación 2',
    //        description: 'Descripción 2'
    //    },
    //    {
    //        title: 'Título de Notificación 3',
    //        description: 'Descripción 3'
    //    }
    //  ];
    
    
    return (
        <nav>
            <a href="http://localhost:8080/Home">
                <img
                    className="navb_left"
                    src={Logo}
                    alt="Logo y nombre D'Clase"                
                    />
            </a>

                <a onClick={showDrawerFAQ}>
                    <img
                    className="navb_right"
                    src={Help}
                    alt="Ayuda"
                    />
                </a>          


                <Badge count = {data.length} className="navb_right"
                    offset={[-18,22]}>
                <a onClick={showDrawerNoti}>
                    <img
                    className="navb_right"
                    src={Notifications}
                    alt="Notificaciones"
                    />
                </a>
                </Badge>
            
                <Dropdown overlay={menu} trigger={['click']}>
                    <a
                        style={{
                            padding: "0",
                            border: "none",
                            margin: "0",
                            float: "right"
                        }}
                        onClick={(e) => e.preventDefault()}>
                        <Space>
                            <img className="navb_right" src={Account} alt="Mi cuenta"
                            />
                        </Space>
                    </a>
                </Dropdown> 
                

            <hr/>    

           

        <Drawer title= {<p className="notiName"><b>Notificaciones</b></p>}
                placement="right"
                onClose={onCloseNoti} visible={visibleNoti}>
        
        <List
            itemLayout="horizontal"            
            dataSource={data}
            renderItem={(item) => (
            <List.Item>
                <a href="http://localhost:8080/Debtors">
                <Alert
                message={item.title}
                description={item.descrpition}
                type="warning"
                showIcon
                />
                </a>             
            </List.Item>
            )}
        />    
        </Drawer>

        <Drawer title= {<p className="notiName"><b>Ayuda</b></p>}
                placement="right"
                onClose={onCloseFAQ} visible={visibleFAQ}>
        
        <Faq data={faq}  config={config} />
        </Drawer>

        </nav>
    );
}


export default NavBar;
