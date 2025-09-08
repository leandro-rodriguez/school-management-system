
import './Dropdown.css';
import { Select } from 'antd';
import React from 'react';

const { Option } = Select;

const Dropdown = (props) => {
    return (
        <Select
            style={{
                marginLeft: "5%",
                width: "300px"
            }}
            showSearch
            placeholder={props.title}
            optionFilterProp="children"
            onChange={props.onChange}
            filterOption={(input, option) => option.children.toLowerCase().includes(input.toLowerCase())}
        >
            {props.options.map((option) => <Option key={option.key}>{props.print(option)}</Option>)}
        </Select>
    );
};

export default Dropdown;

