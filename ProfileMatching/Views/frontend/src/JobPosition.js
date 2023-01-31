import * as React from 'react';
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Typography from '@mui/material/Typography';
import { CardActionArea, Grid } from '@mui/material';
import useFetch from './useFetch';
import { Container } from '@mui/system';


export default function JobPosition() {
    const {data: jPosition, isPending, error} = useFetch('api/JobPosition');
    console.log(jPosition);
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
                                image="/static/images/cards/contemplative-reptile.jpg"
                                alt="green iguana" />
                            <CardContent>
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