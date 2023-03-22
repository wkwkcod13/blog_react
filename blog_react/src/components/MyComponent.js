import React, { useState, useEffect } from 'react';

function MyComponent() {
    const [data, setData] = useState([]);
    useEffect(() => {
        fetchData();
    }, []);

    const fetchData = async () => {
        const response = await fetch("https://localhost:44372/Blog",
            {
                method: "GET"
            })
            .then(async res => {
            console.log(res);
                console.log(res.status + "_" + res.statusText);

                let jsonData = await res.json();

                console.log(jsonData);
        setData(jsonData);
            })
            .catch(res => {
                console.log(res);
            });
    }

    const itemElement = data.map((item, index) => (
        <div key={index}>{item.blogId}</div>
    ));

    return (
        <div>
            <h1>Todo List</h1>
            {itemElement}
            <table>
                <tbody>
                    {
                        data.map((item, index) => (
                            <tr key={index}>
                                <td>{item.blogId}</td>
                                <td>{item.title}</td>
                    </tr>
                        ))
                    }
                </tbody>
            </table>
        </div>
    );
}

export default MyComponent;