import React, { useEffect } from "react";
import NavBar from "../components/NavBar/NavBar";
import {useState} from 'react';
import "./collapse.css";
import CRUD_Table from "../components/Table/CRUD_Table";
import {Button, Collapse, DatePicker, Modal} from "antd";
import moment from "moment";
import Dropdown from "../components/Dropdown/Dropdown";
import axios from "axios";

const { Panel } = Collapse;

const onChange = (key) => {
    console.log(key);
};

const SalaryPaymentControlDetails = () => {
    const [courses, setCourses] = useState([]);

    const [courseSelected, setCourseSelected] = useState();

    console.log(`selected ${courseSelected}`);

    const getDataCourses = async () =>
        await axios.get('http://localhost:5145/api/Courses')
            .then(resp=>{
                setCourses(resp.data);
            });

    useEffect(()=>{
        getDataCourses();
    },[]);

    const fixedSalaryPaymentColumns = [
        {
            title: 'Cargo',
            dataIndex: 'position',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.position.localeCompare(b.position)
            },
        },
        {
            title: 'Importe',
            dataIndex: 'income',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.income.localeCompare(b.income)
            },
        }
    ];

    const fixedSalaryPaymentColumnsTableID = 'fixedSalaryPaymentColumnsTable';
    const fixedSalaryPaymentColumnsSearchboxID = 'fixedSalaryPaymentColumnsSearchbox';

    const percentageSalaryPaymentColumns = [
        {
            title: 'Grupo',
            dataIndex: 'group',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.group.localeCompare(b.group)
            },
        },
        {
            title: 'Ingreso del grupo',
            dataIndex: 'groupIncome',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.groupIncome.localeCompare(b.groupIncome)
            },
        },
        {
            title: 'Importe',
            dataIndex: 'income',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.income.localeCompare(b.income)
            },
        }
    ];

    const percentageSalaryPaymentColumnsTableID = 'percentageSalaryPaymentColumnsTable';
    const percentageSalaryPaymentColumnsSearchboxID = 'percentageSalaryPaymentColumnsSearchbox';

    return (
        <div>
            <NavBar></NavBar>
            <Collapse onChange={onChange} ghost>
                <Panel header="Salario fijo: $___" key="1">
                    <CRUD_Table title={""}
                                columns={fixedSalaryPaymentColumns}
                                operations={[]}
                                url={"http://localhost:5145/api/TeacherCourseRelation"}
                                tableID={fixedSalaryPaymentColumnsTableID}
                                searchboxID={fixedSalaryPaymentColumnsSearchboxID}
                    thereIsDropdown={false}
                        FormsInitialValues={{ key: "string" }}
                    ></CRUD_Table>
                </Panel>

                <Panel header="Salario porcentual: $___" key="2">
                    <Dropdown
                        title={"Curso"}
                        options={courses}
                        onChange={setCourseSelected}
                        print={(course) => (course.name)}
                    />
                    <CRUD_Table title={""}
                                columns={percentageSalaryPaymentColumns}
                                operations={[]}
                                url={"http://localhost:5145/api/TeacherCourseRelation" + `/${courseSelected}`}
                                tableID={percentageSalaryPaymentColumnsTableID}
                                searchboxID={percentageSalaryPaymentColumnsSearchboxID}
                    thereIsDropdown={false}
                        FormsInitialValues={{ key: "string" }}
                    ></CRUD_Table>
                </Panel>
            </Collapse>
            <p className={"total_p"}><strong>Total: $___</strong></p>
        </div>
    );
};

export default SalaryPaymentControlDetails;