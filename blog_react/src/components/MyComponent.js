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
    return (
        <div>
            <h1>Todo List</h1>
            <span>{data}</span>
            <table>
                {data.map(item => (
                    <tr>
                        <td>{item.BlogId}</td>
                        <td>{item.Title}</td>
                        <td>{item.Description}</td>
                    </tr>
                ))}
            </table>
        </div>
    );
}

export default MyComponent;