import * as React from 'react';
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Typography from '@mui/material/Typography';
import { CardActionArea, Grid } from '@mui/material';
import { Container } from '@mui/system';
import { useEffect, useState } from 'react';
import axios from 'axios';
import { JobPosition } from '../models/jobPosition';
import { useStore } from '../stores/store';
import JobPositionsList from '../../features/jobPositions/dashboard/JobPositionsList';
//import {Directory} from '../../../wwwroot/assets/images/';

export default function JobPositionsComponent() {
  const [jobPositions, setJobPositions] = useState<JobPosition[]>([]);

  const { jobPositionStore } = useStore();
  /*   const [isPending, setIsPending] = useState(true);
  const [error, setError] = useState(null);
 */
  useEffect(() => {
    axios
      .get<JobPosition[]>('http://localhost:5048/api/v1/jobposition')
      .then((response) => {
        setJobPositions(response.data);
      });
  }, []);

  var path = 'images/';

  return <JobPositionsList jobPositions={jobPositions} />;
}
