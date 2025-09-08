import React from "react";
import NavBar from "../components/NavBar/NavBar";
import CRUD_Table from "../components/Table/CRUD_Table";

const Debtors = () => {
    const columns = [
        {
            title: 'CI',
            dataIndex: 'CI',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.CI.localeCompare(b.CI)
            },
        },
        {
            title: 'Nombre',
            dataIndex: 'name',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.name.localeCompare(b.name)
            },
        },
        {
            title: 'Apellidos',
            dataIndex: 'lastName',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.lastName.localeCompare(b.lastName)
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
            title: 'Deuda',
            dataIndex: 'debt',
            dataType: 'number',
            sorter: {
                compare: (a, b) => a.debt.localeCompare(b.debt)
            },
        },
        {
            title: 'Retraso',
            dataIndex: 'dealy',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.dealy.localeCompare(b.dealy)
            },
        },
    ];

    const tableID = 'debtorsTable';
    const searchboxID = 'debtorsSearchbox';

    return (
        <div>
            <NavBar></NavBar>
            <CRUD_Table
                title={"Deudores"}
                columns={columns}
                operations={["details"]}
                url={"http://localhost:5145/api/Debtors"}
                tableID={tableID}
                searchboxID={searchboxID}
                link={"../StudentDetails"}
            thereIsDropdown={false}
                        FormsInitialValues={{ key: "string" }}
            >
            </CRUD_Table>
        </div>
    );
};

export default Debtors;