import { Box, Button, Card, CardActionArea, CardContent, CardMedia, Grid, Typography } from '@mui/material';
import { useState } from 'react';
import { JobPosition } from '../../../app/models/JobPosition';

interface Props {
  jobPosition: JobPosition;
  handleApply: (arg0: number) => void;
  path: string;
}

export default function JobPositionCard({ jobPosition, handleApply, path }: Props) {
  return (
    <Grid item xs={4}>
      <Card key={jobPosition.id}>
        <CardActionArea>
          <CardMedia
            component="img"
            height="200"
            image={path + jobPosition.company.logo}
            sx={{ objectFit: 'contain' }}
          />
          <CardContent>
            <Typography gutterBottom variant="h5" component="div">
              {jobPosition.title}
            </Typography>
            <Typography variant="body2" color="text.secondary">
              {jobPosition.company.name}
            </Typography>
            <Typography variant="body2" color="text.secondary">
              Requirements: {jobPosition.skillSet}
            </Typography>
            <Typography variant="body2" color="text.secondary">
              <>Skadon më: {jobPosition.expiryDate}</>
            </Typography>
            <Box sx={{ mt: 2 }}>
              <Button
                variant="contained"
                onClick={() => {
                  handleApply(jobPosition.id);
                }}
              >
                Apply
              </Button>
            </Box>
          </CardContent>
        </CardActionArea>
      </Card>
    </Grid>
  );
}
