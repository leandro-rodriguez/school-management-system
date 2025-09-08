import React from "react";
import NavBar from "../components/NavBar/NavBar";
import {Divider, Tabs} from "antd";
import { useParams } from "react-router-dom";
import CRUD_Table from "../components/Table/CRUD_Table";
import Login from "../components/Login/Login";
import {useState} from 'react';
import axios from "axios";
import {DeleteTwoTone, EditTwoTone} from "@ant-design/icons";
import "./detailsHeader.css";

const { TabPane } = Tabs;

const onChange = (key) => {
    console.log(key);
};

const WorkerDetails = () => {

    const { id } = useParams();

    const positionsColumns = [
        {
            title: 'Cargo',
            dataIndex: 'position',
            width: '15%',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.name.localeCompare(b.name)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca nombre",
                },
                {
                    whitespace: true,
                    message: "Introduzca nombre"
                }
            ],
        },
        {
            title: 'Salario fijo',
            dataIndex: 'fixedSalary',
            width: '15%',
            editable: true,
            dataType: 'number',
            sorter: {
                compare: (a, b) => a.salary - b.salary
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca salario fijo",
                }
            ]
        }
    ];
    const positionsTableID = 'PositionsTable';
    const positionsSearchboxID = 'PositionsSearchbox';

    const acumulatedSalaryColumns = [
        {
            title: 'Fecha',
            dataIndex: 'date',
            width: '15%',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.date.localeCompare(b.date)
            },
        },
        {
            title: 'Salario Fijo',
            dataIndex: 'totalFixSalary',
            width: '15%',
            dataType: 'number',
            sorter: {
                compare: (a, b) => a.fixedSalary - b.fixedSalary
            },
        },
        {
            title: 'Salario Porcentual',
            dataIndex: 'totalCoursesPorcentualPayment',
            width: '15%',
            dataType: 'number',
            sorter: {
                compare: (a, b) => a.percentageSalary - b.percentageSalary
            },
        },
        {
            title: 'Total',
            dataIndex: 'total',
            width: '15%',
            dataType: 'number',
            sorter: {
                compare: (a, b) => a.total - b.total
            },
        }
    ];
    const acumulatedSalaryTableID = 'AcumulatedSalaryTable';
    const acumulatedSalarySearchboxID = 'AcumulatedSalarySearchbox';

    const [loggedIn] = useState(()=>{
        if (localStorage['token'] == null)
            return false;

        let respOk = true;

        const JWT = JSON.parse(localStorage['token']);

        axios.get("http://localhost:5145/api/Authenticate/loggedIn", 
                    { headers: { "Authorization": `Bearer ${JWT.token}` } })
                .catch((err) => {
                respOk = false;
                console.log(err.response);
            });

        return respOk;
    });
         
    if (!loggedIn)
        window.location.replace("http://localhost:8080/");

    return (
        <div>
            <NavBar></NavBar>
            <Divider className={"detailsHeader"}>
                <strong>Nombre</strong> <Divider type="vertical" />
                <strong>Apellidos</strong> <Divider type="vertical" />
                CI <Divider type="vertical" />
                Teléfono <Divider type="vertical" />
                Dirección <Divider type="vertical" />
                Fecha de inicio en la sede
            </Divider>
            <Tabs centered defaultActiveKey="1" onChange={onChange}>
                <TabPane tab="Cargos actuales" key="1">
                    <CRUD_Table title={"Cargos"}
                                columns={positionsColumns}
                                operations={["edit","delete","add"]}
                                url={"http://localhost:5145/api/WorkerPositionRelation/" + `${id}`}
                                tableID={positionsTableID}
                                searchboxID={positionsSearchboxID}
                    thereIsDropdown={false}
                        FormsInitialValues={{ key: "string" }}
                    ></CRUD_Table>
                </TabPane>
                <TabPane tab="Control de salario" key="2">
                    <CRUD_Table title={"Salario Acumulado"}
                                columns={acumulatedSalaryColumns}
                                operations={["details"]}
                                url={"http://localhost:5145/api/ConsultWorkerSalary/"+ `${id}`}
                                tableID={acumulatedSalaryTableID}
                                searchboxID={acumulatedSalarySearchboxID}
                                link={"../SalaryPaymentControlDetails"}
                    thereIsDropdown={false}
                        FormsInitialValues={{ key: "string" }}
                    ></CRUD_Table>
                </TabPane>
            </Tabs>
        </div>
    );
};

export default WorkerDetails;