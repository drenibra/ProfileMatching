import { useState, useEffect } from 'react';

const useFetch = (url) =>{
    const [data, setData] = useState([]);
    const[isPending, setIsPending] = useState(true);
    const[error, setError] = useState(null);
    useEffect(() =>{
        setTimeout(()=>{
            fetch('http://localhost:5048/'+url)
            .then(res =>{
                if(!res.ok){
                    throw Error('could not fetch the data from that source');
                }
                return res.json();
            })
            .then(dt =>{
                setData(dt);
                setIsPending(false);
                setError(null);
            })
            .catch(err =>{
                setIsPending(false);
                setError(err.message);
            })
        }, 1000);
    },[url]);

    return {data, isPending, error}
}

export default useFetch;