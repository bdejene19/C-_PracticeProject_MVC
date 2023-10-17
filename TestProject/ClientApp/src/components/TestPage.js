import React from 'react';

export const TestPage = () => {
    const handleClick = () => {
        const res = fetch("test").then(res => res.json()).then(res => {
            console.log('my final: ', res);
        }).catch(e => console.log('my error: ', e));
    }
    return (
        <div>
            hello
            <button onClick={() => handleClick()}>Call C# Test HttpGet Method</button>
        </div>
    )
}