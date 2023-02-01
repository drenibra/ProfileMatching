import * as React from 'react';
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Typography from '@mui/material/Typography';
import { CardActionArea, Grid } from '@mui/material';
import useFetch from './useFetch';
import { Container } from '@mui/system';
//import {Directory} from '../../../wwwroot/assets/images/';

export default function JobPosition() {
    const {data: jPosition, isPending, error} = useFetch('api/JobPosition');
    var path = "../../../wwwroot/assets/images/";
    
  return (
    <Container>
    <Grid container spacing={12}>
        {
            jPosition.map(item =>{
                return(
                    <Grid item xs={4}>
                    <Card key={item.id}>
                        <CardActionArea>
                            <CardMedia
                                component="img"
                                height="140"
                                image={path+item.company.logo} />
                            <CardContent>
                                {console.log(item.company.logo)}
                                <Typography gutterBottom variant="h5" component="div">
                                {item.title}
                                </Typography>
                                <Typography variant="body2" color="text.secondary">
                                    Description: {item.description}
                                </Typography>
                                <Typography variant="body2" color="text.secondary">
                                    Requirements: {item.skillSet}
                                </Typography>
                                <Typography variant="body2" color="text.secondary">
                                    Skadon më: {item.expiryDate}
                                </Typography>
                            </CardContent>
                        </CardActionArea>
                    </Card>
                    </Grid>
                )
            }
           )
        }
    </Grid>
    </Container>
  );
}