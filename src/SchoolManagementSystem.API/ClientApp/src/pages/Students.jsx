import React from "react";
import NavBar from "../components/NavBar/NavBar";
import CRUD_Table from "../components/Table/CRUD_Table";
import Login from "../components/Login/Login";
import {useState, useRef } from 'react';
import axios from "axios";
import { SearchOutlined } from '@ant-design/icons';
import { Button, Input, Space, Table } from 'antd';
import Highlighter from 'react-highlight-words';

const Students = () => {

    const [searchText, setSearchText] = useState('');
    const [searchedColumn, setSearchedColumn] = useState('');
    const searchInput = useRef(null);    

    const handleSearch = (selectedKeys, confirm, dataIndex) => {
        confirm();
        setSearchText(selectedKeys[0]);
        setSearchedColumn(dataIndex);
    };

    const handleReset = (clearFilters) => {
        clearFilters();
        setSearchText('');
    };

    const getColumnSearchProps = (dataIndex) => ({
        filterDropdown: ({ setSelectedKeys, selectedKeys, confirm, clearFilters }) => (
          <div
            style={{
              padding: 8,
            }}
          >
            <Input
              ref={searchInput}
              placeholder={`Search ${dataIndex}`}
              value={selectedKeys[0]}
              onChange={(e) => setSelectedKeys(e.target.value ? [e.target.value] : [])}
              onPressEnter={() => handleSearch(selectedKeys, confirm, dataIndex)}
              style={{
                marginBottom: 8,
                display: 'block',
              }}
            />
            <Space>
              <Button
                type="primary"
                onClick={() => handleSearch(selectedKeys, confirm, dataIndex)}
                icon={<SearchOutlined />}
                size="small"
                style={{
                  width: 90,
                }}
              >
                Search
              </Button>
              <Button
                onClick={() => clearFilters && handleReset(clearFilters)}
                size="small"
                style={{
                  width: 90,
                }}
              >
                Reset
              </Button>
              <Button
                type="link"
                size="small"
                onClick={() => {
                  confirm({
                    closeDropdown: false,
                  });
                  setSearchText(selectedKeys[0]);
                  setSearchedColumn(dataIndex);
                }}
              >
                Filter
              </Button>
            </Space>
          </div>
        ),
        filterIcon: (filtered) => (
          <SearchOutlined
            style={{
              color: filtered ? '#1890ff' : undefined,
            }}
          />
        ),
        onFilter: (value, record) =>
          record[dataIndex].toString().toLowerCase().includes(value.toLowerCase()),
        onFilterDropdownVisibleChange: (visible) => {
          if (visible) {
            setTimeout(() => searchInput.current?.select(), 100);
          }
        },
        render: (text) =>
          searchedColumn === dataIndex ? (
            <Highlighter
              highlightStyle={{
                backgroundColor: '#ffc069',
                padding: 0,
              }}
              searchWords={[searchText]}
              autoEscape
              textToHighlight={text ? text.toString() : ''}
            />
          ) : (
            text
          ),
      });
    
    function levels(){
        var list = [];
        //var arr = [list];
        axios.get("http://localhost:5145/api/EducationEnum")
            .then(resp=>{
                resp.data.forEach(element => {
                   list.push({
                    text: element,
                    value: element,
                   })
                });
            });
        console.log(list);
        return list;
    }

    function filtersFoundSubMenu(comparer, count){
        var children = [];
        for (let index = 0; index < count; index++) {
            let val = 50 * index;
            children.push({
                text: val,
                value: [comparer, val]
            });  
        }        
        return children;
    }

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

    const columns = [
        {
            title: 'Nombre',
            dataIndex: 'name',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.name.localeCompare(b.name)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca el nombre.",
                },
                {
                    whitespace: true,
                    message: "Introduzca el nombre."
                },
                {
                    pattern: /^[a-zA-Z]{2,}(\s[a-zA-Z]{2,})?(\s[a-zA-Z]{2,})?(\s[a-zA-Z]{2,})?$/,
                    message: 'El nombre solo puede contener letras (dos como mínimo). En caso de ser compuesto, deben estar separados por un único espacio.'
                },
            ],
            ...getColumnSearchProps('name')
        },
        {
            title: 'Apellidos',
            dataIndex: 'lastName',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.lastName.localeCompare(b.lastName)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca los apellidos.",
                },
                {
                    whitespace: true,
                    message: "Introduzca los apellidos."
                },
                {
                    pattern: /^[a-zA-Z]{2,}(\s[a-zA-Z]{2,})?(\s[a-zA-Z]{2,})?(\s[a-zA-Z]{2,})?$/,
                    message: 'Los apellidos solo pueden contener letras (dos como mínimo) y estar separados por un único espacio.'
                },
            ],
            ...getColumnSearchProps('lastName')
        },
        {
            title: 'Carnet de identidad',
            dataIndex: 'idCardNo',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.idCardNo.localeCompare(b.idCardNo)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca el carnet de identidad.",
                },
                {
                    whitespace: true,
                    message: "Introduzca el carnet de identidad."
                },
                {
                    pattern: /^\d{11}$/,
                    message: 'El carnet de identidad solo puede contener números y tiene tamaño 11.'
                }
            ],
            ...getColumnSearchProps('idCardNo')
        },
        {
            title: 'Dirección',
            dataIndex: 'address',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.address.localeCompare(b.address)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca la dirección.",
                },
                {
                    whitespace: true,
                    message: "Introduzca la dirección."
                },
                {
                    pattern: /^[a-zA-Z0-9,#/&\-.\s]{1,100}$/,
                    message: "La dirección debe tener máximo 100 caracteres."
                }
            ],
            ...getColumnSearchProps('address')
        },
        {
            title: 'Grado de escolaridad',
            dataIndex: 'scholarityLevel',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.scholarityLevel.localeCompare(b.scholarityLevel)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca el grado de escolaridad.",
                },
                {
                    whitespace: true,
                    message: "Introduzca el grado de escolaridad."
                },
                {
                    pattern: /^\bPrimaria|Secundaria|EscuelaOficios|TecnicoMedio|Preuniversitario|Universidad|Posgrado\b$/,
                    message: "El nivel escolar debe ser de uno de los siguientes tipos: Primaria, Secundaria, EscuelaOficios, " +
                        "TecnicoMedio, Preuniversitario, Universidad, Posgrado."
                }
            ],
            filters: levels(),            
            onFilter: (value, record) => record.scholarityLevel
                                    .toUpperCase().indexOf(value.toUpperCase()) === 0,
        },
        {
            title: 'Fecha de inicio en la sede',
            dataIndex: 'dateBecomedMember',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.dateBecomedMember.localeCompare(b.dateBecomedMember)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca la fecha de inicio en la sede.",
                },
                {
                    whitespace: true,
                    message: "Introduzca la fecha de inicio en la sede."
                },
                {
                    //pattern: /^(0[1-9]|1[0-2])[-/.](0[1-9]|[12][0-9]|3[01])[-/.]\d{4}$/,
                    pattern: /^\b1[-/.](0[1-9]|[12][0-9]|3[01])[-/.](19[0-9][0-9]|20[0-9][0-9])|2[-/.](0[1-9]|[12][0-9]|2[08])[-/.](19[0-9][0-9]|20[0-9][0-9])|3[-/.](0[1-9]|[12][0-9]|3[01])[-/.](19[0-9][0-9]|20[0-9][0-9])|4[-/.](0[1-9]|[12][0-9]|3[00])[-/.](19[0-9][0-9]|20[0-9][0-9])|5[-/.](0[1-9]|[12][0-9]|3[01])[-/.](19[0-9][0-9]|20[0-9][0-9])|6[-/.](0[1-9]|[12][0-9]|3[00])[-/.](19[0-9][0-9]|20[0-9][0-9])|7[-/.](0[1-9]|[12][0-9]|3[01])[-/.](19[0-9][0-9]|20[0-9][0-9])|8[-/.](0[1-9]|[12][0-9]|3[01])[-/.](19[0-9][0-9]|20[0-9][0-9])|9[-/.](0[1-9]|[12][0-9]|3[00])[-/.](19[0-9][0-9]|20[0-9][0-9])|10[-/.](0[1-9]|[12][0-9]|3[01])[-/.](19[0-9][0-9]|20[0-9][0-9])|11[-/.](0[1-9]|[12][0-9]|3[00])[-/.](19[0-9][0-9]|20[0-9][0-9])|12[-/.](0[1-9]|[12][0-9]|3[01])[-/.](19[0-9][0-9]|20[0-9][0-9])\b$/,
                    message: "El formato de la fecha debe ser M/d/yyyy. Ej: 4/22/2021."
                }
            ],
            ...getColumnSearchProps('dateBecomeMember')
        },
        {
            title: 'Teléfono',
            dataIndex: 'phoneNumber',
            editable: true,
            dataType: 'number',
            sorter: {
                compare: (a, b) => a.phoneNumber - b.phoneNumber
            },
            rules: [
                {
                    whitespace: true,
                    message: "Introduzca el número de teléfono."
                },
                {
                    pattern: /^[0-9]+$/,
                    message: 'El teléfono solo puede contener números.'
                }
            ],
            ...getColumnSearchProps('phoneNumber')
        },
        {
            title: 'Fondos',
            dataIndex: 'founds',
            editable: true,
            dataType: 'number',
            sorter: {
                compare: (a, b) => a.founds - b.founds
            },
            rules: [
                {
                    pattern: /^[0-9]+$/,
                    message: 'Los fondos solo pueden contener números.'
                }
            ],
            filters: [
                {
                    text: "Mayor",
                    value: "",
                    children: filtersFoundSubMenu(">=", 11)
                },
                {
                    text: "Menor",
                    value: "",
                    children: filtersFoundSubMenu("<=", 11)
                }
            ],
            onFilter: (value, record) => {
                console.log(value);
                if (value[0] == ">="){
                    return record.founds >= value[1];
                } else {
                    return record.founds <= value[1];
                }
            }            
        },
        {
            title: 'Nombre del tutor',
            dataIndex: 'tuitorName',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.tuitorName.localeCompare(b.tuitorName)
            },
            rules: [
                {
                    pattern: /^[a-zA-Z]{2,}(\s[a-zA-Z]{2,})?(\s[a-zA-Z]{2,})?(\s[a-zA-Z]{2,})?$/,
                    message: 'El nombre solo puede contener letras (dos como mínimo). En caso de ser compuesto, deben estar separados por un único espacio.'
                }
            ],
            ...getColumnSearchProps('tuitorName')
        },
        {
            title: 'Teléfono del tutor',
            dataIndex: 'tuitorPhoneNumber',
            editable: true,
            dataType: 'number',
            sorter: {
                compare: (a, b) => a.tuitorPhoneNumber - b.tuitorPhoneNumber
            },
            rules: [
                {
                    pattern: /^[0-9]+$/,
                    message: 'El teléfono solo puede contener números.'
                }
            ],
            ...getColumnSearchProps('tuitorPhoneNumber')
        }        
    ];

    const tableID = 'StudentsTable';
    const searchboxID = 'StudentsSearchbox';

    return (
        <div>
            <NavBar></NavBar>
            <CRUD_Table 
                title={"Estudiantes"} 
                columns={columns} 
                operations={["edit","delete","add","details","trash"]}
                url={"http://localhost:5145/api/Students"}
                tableID={tableID}
                searchboxID={searchboxID}
                link={"../StudentDetails"}
                recycle_link={"../StudentsRecycleBin"}
            thereIsDropdown={false}
                        FormsInitialValues={{ key: "string" }}
            >
            </CRUD_Table>
        </div>
    );
}

export default Students;