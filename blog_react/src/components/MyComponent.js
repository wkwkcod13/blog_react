import React, { useState, useEffect } from 'react';

function MyComponent() {
    const [data, setData] = useState([]);
    useEffect(() => {
        fetchData();
    }, []);

    const fetchData = async () => {
        const response = await fetch('https://localhost:44372/Blog', { method: 'GET', mode: 'no-cors' }).catch(res => {
            console.log(res);
        });
        const jsonData = await response.json();
        setData(jsonData);
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