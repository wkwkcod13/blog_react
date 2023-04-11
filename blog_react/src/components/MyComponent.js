import React, { useState, useEffect } from 'react';
import ApiRoutes, { } from '../ApiRoutes';
import jwtToken from './jwtToken';

function MyComponent() {
    const [data, setData] = useState([]);
    useEffect(() => {
        fetchData();
    }, []);

    const fetchData = async () => {
        await fetch(ApiRoutes.ApiRoot + "/Blog",
            {
                method: "GET",
                headers: {
                    'Authorization': `Bearer ${jwtToken.fnTokenGet()}`
                }
            })
            .then(async (res) => {
                //console.log(res.status + "_" + res.statusText);
                let jsonData = await res.json();
                //console.log(jsonData);
                setData(jsonData);
            })
            .catch((res) => {
                console.log(res);
            });
    };

    const itemElement = data.map((item, index) => (
        <div key={index}>{item.blogId}</div>
    ));

    return (
        <div>
            <h1>Todo List</h1>
        </div>
    );
};

export default MyComponent;