import {Button, Modal, Form, InputNumber, Input, Popconfirm, Table, Typography} from 'antd';
import {
    DeleteTwoTone,
    EditTwoTone,
    SaveTwoTone,
    CloseSquareTwoTone,
    ExclamationCircleTwoTone,
    EllipsisOutlined,
    DeleteRowOutlined,
    RedoOutlined, EditOutlined, SaveOutlined, CloseSquareOutlined
} from "@ant-design/icons";
import {useContext, useEffect, useRef, createContext, useState} from 'react';
import "./CRUD_Table.css";
import axios from 'axios';
import { render } from 'react-dom';
import Dropdown from "../Dropdown/Dropdown";
import { Select } from 'antd';
const { Option } = Select;

const EditableContext = createContext(null);


const EditableCell = ({
                        editing,
                        dataIndex,
                        title,
                        inputType,
                        record,
                        index,
                        children,
                        ...restProps
                    }) => {
    const inputNode = inputType === 'number' ? <InputNumber/> : <Input/>;
    return (
        <td {...restProps}>
            {editing ? (
                <Form.Item
                    name={dataIndex}
                    style={{
                        margin: 0,
                    }}
                    rules={[
                        {
                            required: true,
                            message: `Please Input ${title}!`,
                        },
                    ]}
                >
                    {inputNode}
                </Form.Item>
            ) : (
                children
            )}
        </td>
    );
};

const CRUD_Table = (props) => {
    const [form] = Form.useForm();
    const [data, setData] = useState([]);
    const [headers] = useState(props.columns);
    const [editingKey, setEditingKey] = useState('');

    var showAdd, showDelete, showTrash;

    const columns = [];

    const temp = props.columns;
    for (let i = 0; i < temp.length; i++) {
        columns.push(temp[i]);
    }

    for (let i = 0; i < props.operations.length; i++) {
        if (props.operations[i] === 'edit'){
            columns.push(
                {
                    title: 'Editar',
                    dataIndex: 'operation',
                    width: "1%",
                    render: (_, record) => {
                        const editable = isEditing(record);
                        return editable ? (
                            <span>
                    <Typography.Link
                        onClick={() => save(record.key)}
                        style={{
                            marginRight: 8,
                        }}
                    >
                      <SaveOutlined style={{color: "black"}}/>
                    </Typography.Link>
                    <Popconfirm title="¿Está seguro que quiere cancelar?" onConfirm={cancel}>
                      <a><CloseSquareOutlined style={{color: "black"}}/></a>
                    </Popconfirm>
                  </span>
                        ) : (
                            <Typography.Link disabled={editingKey !== ''} onClick={() => edit(record)}>
                                <EditOutlined style={{color: "black"}}/>
                            </Typography.Link>
                        );
                    },
                },
            );
        }
        if (props.operations[i] === 'add'){
            showAdd = true;
        }
        if (props.operations[i] === 'delete'){
            columns.push(
                {
                    title: 'Eliminar',
                    dataIndex: 'operation',
                    width: "1%",
                    render: (_, record) =>
                        data.length >= 1 ? (
                            <Popconfirm title="¿Está seguro de que quiere eliminar esta fila?" cancelText={"Cancelar"}
                                        okText={"Aceptar"} onConfirm={() => Delete(record.key)}
                                        icon={<ExclamationCircleTwoTone twoToneColor="#eb2f96"/>}>
                                <DeleteRowOutlined />
                            </Popconfirm>
                        ) : null,
                }
            );
            showDelete = true;
        }
        if (props.operations[i] === 'details'){
            columns.push(
                {
                    title: 'Detalles',
                    dataIndex: 'operation',
                    width: "1%",
                    render: (_, record) =>
                        <a href={props.link + `/${record.key}`}><EllipsisOutlined /></a>
                }
            );
        }
        if (props.operations[i] === 'trash'){
            showTrash = true;
        }
        if (props.operations[i] === 'restore'){
            columns.push(
                {
                    title: 'Restaurar',
                    dataIndex: 'operation',
                    width: "1%",
                    render: (_, record) =>
                        <Popconfirm title="¿Está seguro de que quiere restaurar esta fila?" cancelText={"Cancelar"}
                                    okText={"Aceptar"}
                                    onConfirm={async ()=>{
                                        await axios.post(props.restore_url + `/${record.key}`).catch((resp) => console.log(resp.data));
                                        console.log(props.restore_url, record.key);
                                        await getData();
                                    }}
                                    icon={<ExclamationCircleTwoTone twoToneColor="orange"/>}>
                            <RedoOutlined />
                        </Popconfirm>
                }
            );
        }
    }

    const showOpBox = showAdd || showDelete;

    const [isEditingModalVisible, setIsEditingModalVisible] = useState(false);

    const isEditing = (record) => record.key === editingKey;

    const edit = (record) => {

        console.log(record);

        form.setFieldsValue({
            ...record,
        });
        setEditingKey(record.key);
    };

    const cancel = () => {
        setEditingKey('');
    };

    const save = async (key) => {
        try {
            const row = await form.validateFields();
            const newData = [...data];
            const index = newData.findIndex((item) => key === item.key);
            
            if (index > -1) {
                const item = newData[index];
                newData.splice(index, 1, {...item, ...row});
                setData(newData);
                setEditingKey('');
            } else {
                newData.push(row);
                setData(newData);
                setEditingKey('');
            }
            await axios.put(props.url, newData[index]);

        } catch (errInfo) {
            console.log('Validate Failed:', errInfo);
        }
    };

    const Delete = (key) => {
        if (editingKey === key){
            setEditingKey('');
        }

        const index = data.findIndex((item) => key === item.key);

        axios.delete(props.url + `/${data[index].key}`);
        
        const newData = data.filter((item) => item.key !== key);

        setData(newData);
    };

    const DeleteMultipleRows = (keys) => {
        if(keys.length > 0){
            for (let i = 0; i < keys.length; i++) {
                Delete(keys[i]);
            }
        }
    };

    const search = (input_id, table_id) =>{
        var input, filter, table, tr, td, i, j, x, txtValue;
        input = document.getElementById(input_id);
        filter = input.value.toUpperCase();
        table = document.getElementById(table_id);
        tr = table.getElementsByTagName("tr");

        // Loop through all table rows, and hide those who don't match the search query
        for (i = 1; i < tr.length; i++) {
            td = tr[i].getElementsByTagName("td");
            x = true
            for (j = 0; j < td.length; j++) {
                if (td[j]) {
                    txtValue = td[j].textContent || td[j].innerText;
                    if (txtValue.toUpperCase().indexOf(filter) > -1){
                        x = false;
                        break;
                    }
                }
            }
            if(x){
                tr[i].style.display = "none";
            }
            else{
                tr[i].style.display = "";
            }
        }
    };

    const [selRowKeys, setSelRowKeys] = useState([])
    const [selectedRowKeys, setSelectedRowKeys] = useState([])
    const rowSelection = {
        onChange: (selectedRowKeys, selectedRows) => {
            console.log(`selectedRowKeys: ${selectedRowKeys}`, 'selectedRows: ', selectedRows);
            setSelectedRowKeys(selectedRowKeys);
        },
    };

    console.log(rowSelection);

    const getData = async () => 
        await axios.get(props.url)
            .then(resp=>{ 
                setData(resp.data);
            });

    const mergedColumns = columns.map((col) => {
        if (!col.editable) {
            return col;
        }

        return {
            ...col,
            onCell: (record) => ({
                record,
                inputType: col.dataType,
                dataIndex: col.dataIndex,
                title: col.title,
                editing: isEditing(record),
            }),
        };
    });

    useEffect(()=>{
        getData();
    },[]);

    const FormInput = (props)=>{

        return (
            <><Form.Item
                label={props.header.title}
                name={props.header.dataIndex}
                rules={props.header.rules}
                hasFeedback={true}
            >
                <Input onChange={props.onChange}/>
            </Form.Item></>
        );
    };

    const Forms = (props)=>{
        var [newItem, setNewItem] = useState(props.InitialValues);
        const [dropDownOptions, setDropDownOptions] = useState([]);

        const getOptions = async () =>
            await axios.get(props.dropDownUrl)
                .then(resp=>{
                    setDropDownOptions(resp.data);
                });

        useEffect(()=>{
            getOptions();
        },[]);

        const updateValue = (header, e) => {
            newItem[header.dataIndex] = e.target.value;
            console.log(newItem);
        };
        
        const itemSelected = (key) => {
            const optionSelected = dropDownOptions.find(
                (item) => key === item.key);
            
            let tmp = {...newItem};

            props.dropDownHeaders.map((header) =>{
                tmp[header] = optionSelected[props.map.get(header)];
            });

            setNewItem(tmp);
        };


        return (
            <Modal className={"editModal"}
                   title={"Añadir nuevo elemento a la tabla"}
                   visible={isEditingModalVisible}
                   centered={true}
                   onCancel={() => setIsEditingModalVisible(false)}
                   footer={null}
            >
                <Form name="hey"
                      autoComplete={"off"}
                      onFinish={async ()=>{
                          await axios.post(props.url, newItem).catch((resp) => console.log(resp.data));
                          console.log(props.url, newItem);
                          await getData();
                          setIsEditingModalVisible(false);
                }}>

                    {props.thereIsDropdown && 
                        <Dropdown
                            title={"Select"}
                            options={dropDownOptions}
                            onChange={itemSelected}
                            print={props.print}
                        />
                    }

                    {props.thereIsDropdown &&
                        headers.map(
                            (header) => {
                                // console.log(header.dataIndex, props.dropDownHeaders, props.dropDownHeaders.some((h) => (h === header.dataIndex)));
                                if (! props.dropDownHeaders.some((h) => (h === header.dataIndex)))
                                    return (<FormInput header={header} onChange={(e) =>{ updateValue(header, e); } } />); 
                            }
                        )
                    }

                    {!props.thereIsDropdown &&
                        headers.map(
                            (header) => { return (<FormInput header={header} onChange={(e) =>{ updateValue(header, e); } } />); }
                        )
                    }

                    <Form.Item style={{float: "left", marginRight: "10px"}}>
                    <Button type="primary" htmlType="submit"
                    >Guardar</Button>
                    </Form.Item>
                    <Form.Item>
                    <Button onClick={()=>{setIsEditingModalVisible(false);}}>Cancelar</Button>
                    </Form.Item>
                </Form>
            </Modal>
        );
    };

    return (
        <div>
            <div className={"container"}>
                <div className="box_title">
                    <p><strong>{props.title}</strong></p>
                </div>

                <div className="box">
                    <i className="fa fa-search" aria-hidden="true"></i>
                    <input
                        type="search"
                        id={props.searchboxID}
                        placeholder="Buscar"
                        onKeyUp={() => {search(props.searchboxID, props.tableID);}}
                    />
                </div>

                {showTrash &&
                    <div className="box">
                        <a className="table_options" href={props.recycle_link}>
                            <i className="fa fa-trash-o"
                               style={{fontSize: "18px"}}
                               aria-hidden="true"
                            >
                            </i>
                        </a>
                    </div>
                }

                {showOpBox &&
                    <div className="box">
                        {showAdd &&
                            <a className="table_options">
                                <i className="fa fa-plus-square-o"
                                   aria-hidden="true"
                                   onClick={() => {
                                       for (let i = 0; i < props.operations.length; i++) {
                                           if (props.operations[i] === 'add') {
                                               setIsEditingModalVisible(true);
                                           }
                                       }
                                   }}>
                                </i>
                            </a>
                        }

                        {showDelete &&
                            <a className="table_options">
                                <i className="fa fa-minus-square-o"
                                   aria-hidden="true"
                                   onClick={() => {
                                       for (let i = 0; i < props.operations.length; i++) {
                                           if (props.operations[i] === 'delete') {
                                               DeleteMultipleRows(selectedRowKeys);
                                           }
                                       }
                                   }}>
                                </i>
                            </a>
                        }
                    </div>
                }

                <div className="box">
                    <p><strong>Total:</strong> {data.length}</p>
                </div>
            </div>

        <Form form={form} component={false}>
            {showDelete &&
                <Table
                    id={props.tableID}
                    components={{
                        body: {
                            cell: EditableCell,
                        },
                    }}
                    rowSelection={{
                        ...rowSelection,
                    }}
                    bordered
                    dataSource={data}
                    columns={mergedColumns}
                    rowClassName="editable-row"
                    pagination={{
                        position: ["bottomCenter"],
                        pageSizeOptions: ["5", "10", "20", "50", "100"],
                        showQuickJumper: true,
                        onChange: cancel,
                    }}
                />
            }
            {!showDelete &&
                <Table
                    id={props.tableID}
                    components={{
                        body: {
                            cell: EditableCell,
                        },
                    }}
                    bordered
                    dataSource={data}
                    columns={mergedColumns}
                    rowClassName="editable-row"
                    pagination={{
                        position: ["bottomCenter"],
                        pageSizeOptions: ["5", "10", "20", "50", "100"],
                        showQuickJumper: true,
                        onChange: cancel,
                    }}
                />
            }
        </Form>

        <Forms
            thereIsDropdown={props.thereIsDropdown}
            dropDownUrl={props.dropDownUrl}
            dropDownHeaders={props.dropDownHeaders}
            url={props.url}
            map={props.map}
            print={props.print}
            InitialValues={props.FormsInitialValues}
        />
            
        </div>
    );
};

export default CRUD_Table;
