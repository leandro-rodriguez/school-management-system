import React from "react";
import NavBar from "../components/NavBar/NavBar";
import {useState, useEffect} from 'react';
import "./collapse.css";
import CRUD_Table from "../components/Table/CRUD_Table";
import {Button, Space, DatePicker, Modal} from "antd";
import moment from "moment";
import axios from "axios";
import Dropdown from "../components/Dropdown/Dropdown";

const dateFormat = 'DD/MM/YYYY';

const disabledDate = (current) => {
    return current && current >= moment().endOf('day');
};

const CoursesPayment = () => {
    const fixedSalaryPaymentColumns = [
        {
            title: 'Curso',
            dataIndex: 'course',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.course.localeCompare(b.course)
            },
        },
        {
            title: 'Grupo',
            dataIndex: 'group',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.group.localeCompare(b.group)
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

    const [isConfirmationModalVisible, setIsConfirmationModalVisible] = useState(false);

    const [students, setStudents] = useState([]);

    const [studentSelected, setStudentSelected] = useState();

    const getData = async () =>
        await axios.get('http://localhost:5145/api/Students')
            .then(resp=>{
                setStudents(resp.data);
            });

    useEffect(()=>{
        getData();
    },[]);

    return (
        <div>
            <NavBar></NavBar>

            <div style={{marginBottom: "10px"}}>
            <Dropdown
                title={"Estudiante"}
                options={students}
                onChange={setStudentSelected}
                print={(student) => (student.name + ' ' + student.lastName)}
            />

            <DatePicker placeholder={"Seleccione la fecha"}
                        disabledDate={disabledDate}
                        defaultValue={moment()}
                        format={dateFormat}
                        style={{
                            float: "right",
                            marginRight: "5%",
                        }}
            />
            </div>

            <CRUD_Table title={""}
                columns={fixedSalaryPaymentColumns}
                operations={[]}
                url={"http://localhost:5145/api/DoStudentPayment" + `/${studentSelected}`}
                tableID={fixedSalaryPaymentColumnsTableID}
                searchboxID={fixedSalaryPaymentColumnsSearchboxID}
                thereIsDropdown={false}
                        FormsInitialValues={{ key: "string" }}
            ></CRUD_Table>
            <div className={"checkout"}>
                <div className={"total"}>
                    <p><strong>Total: $___</strong></p>
                    <p><strong>Por cobrar: $___</strong></p>
                </div>
                <Button className={"checkout_button"} onClick={() => setIsConfirmationModalVisible(true)}>
                    <strong>Registrar cobro</strong>
                </Button>
            </div>
            <Modal title={"Confirmar registro de cobro"}
                   visible={isConfirmationModalVisible}
                   centered={true}
                   cancelText={"Cancelar"}
                   onCancel={() => setIsConfirmationModalVisible(false)}
                   okText={"Aceptar"}
                   onOk={() => setIsConfirmationModalVisible(false)}
            >
                <p>
                    ¿Está seguro de que quiere registar el cobro de _ curso(s) en la fecha _________ al estudiante
                    __________
                    con un importe total de $___?
                </p>
            </Modal>
        </div>
    );
};

export default CoursesPayment;