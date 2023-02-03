import {
  Card,
  CardActionArea,
  CardContent,
  CardMedia,
  Container,
  Grid,
  Typography,
} from '@mui/material';
import path from 'path';
import { JobPosition } from '../../../app/models/jobPosition';

interface Props {
  jobPositions: JobPosition[];
}

export default function JobPositionsList(props: Props) {
  return (
    <Container>
      <Grid container spacing={12}>
        {props.jobPositions.map((item) => {
          return (
            <Grid item xs={4}>
              <Card key={item.id}>
                <CardActionArea>
                  <CardMedia component="img" height="200" image={'path'} />
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
                      <>Skadon më: {item.expiryDate}</>
                    </Typography>
                  </CardContent>
                </CardActionArea>
              </Card>
            </Grid>
          );
        })}
      </Grid>
    </Container>
  );
}
