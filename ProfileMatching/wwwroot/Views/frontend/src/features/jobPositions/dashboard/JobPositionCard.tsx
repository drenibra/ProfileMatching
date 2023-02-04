import {
  Card,
  CardActionArea,
  CardContent,
  CardMedia,
  Grid,
  Typography,
} from '@mui/material';
import axios from 'axios';
import { useState } from 'react';
import { JobPosition } from '../../../app/models/jobPosition';

export default function JobPositionCard(props: JobPosition) {
  const [editMode, setEditMode] = useState(false);

  const handeFormOpen = () => {
    setEditMode(true);
  };
  const handeFormClose = () => {
    setEditMode(false);
  };

  const [logo, setLogo] = useState('');

  const companyLogo = axios
    .get('http://localhost:5048/api/v1/Company/' + props.companyId)
    .then((res: any) => {
      console.log(res.data);
      setLogo(res.data.logo);
    });

  return (
    <Grid item xs={4}>
      <Card key={props.id}>
        <CardActionArea>
          <CardMedia
            component="img"
            height="200"
            image={logo}
            sx={{ objectFit: 'contain' }}
          />
          <CardContent>
            <Typography gutterBottom variant="h5" component="div">
              {props.title}
            </Typography>
            <Typography variant="body2" color="text.secondary">
              Description: {props.description}
            </Typography>
            <Typography variant="body2" color="text.secondary">
              Requirements: {props.skillSet}
            </Typography>
            <Typography variant="body2" color="text.secondary">
              <>Skadon më: {props.expiryDate}</>
            </Typography>
          </CardContent>
        </CardActionArea>
      </Card>
    </Grid>
  );
}