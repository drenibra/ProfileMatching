import { Alert, Box, Button, Card, CardActionArea, CardContent, CardMedia, Grid, Typography } from '@mui/material';
import axios from 'axios';
import { useState } from 'react';
import { JobPosition } from '../../../app/models/JobPosition';

interface Props {
  jobPosition: JobPosition;
  handleApply: (arg0: number) => void;
  setApplied: (arg0: boolean) => void;
  applied: boolean;
}

export default function JobPositionCard({ jobPosition, handleApply, setApplied, applied }: Props) {
  return (
    <Grid item xs={4}>
      <Card key={jobPosition.id}>
        <CardActionArea>
          <CardMedia component="img" height="200" image={jobPosition.company.logo} sx={{ objectFit: 'contain' }} />
          <CardContent>
            <Typography gutterBottom variant="h5" component="div">
              {jobPosition.title}
            </Typography>
            <Typography variant="body2" color="text.secondary">
              Description: {jobPosition.description}
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
                  setApplied(true);
                }}
                disabled={applied}
              >
                Apply
              </Button>
            </Box>
            {applied && <Alert severity="success">Application sent!</Alert>}
          </CardContent>
        </CardActionArea>
      </Card>
    </Grid>
  );
}
