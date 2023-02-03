import { Container, Grid } from '@mui/material';
import axios from 'axios';
import path from 'path';
import { JobPosition } from '../../../app/models/jobPosition';
import JobPositionCard from './JobPositionCard';

interface Props {
  jobPositions: JobPosition[];
}

export default function JobPositionsList(props: Props) {
  return (
    <Container>
      <Grid container spacing={12}>
        {props.jobPositions.map((item) => {
          return (
            <JobPositionCard
              id={item.id}
              title={item.title}
              description={item.description}
              skillSet={item.skillSet}
              createdAt={item.createdAt}
              expiryDate={item.expiryDate}
              companyId={item.companyId}
              category={item.category}
            />
          );
        })}
      </Grid>
    </Container>
  );
}
