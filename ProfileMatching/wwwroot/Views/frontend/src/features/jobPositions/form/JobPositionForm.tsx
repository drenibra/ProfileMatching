import {
  Button,
  Container,
  FormControl,
  FormHelperText,
  Grid,
  Input,
  InputLabel,
  Stack,
  TextareaAutosize,
  TextField,
  Typography,
} from '@mui/material';
import { DesktopDatePicker } from '@mui/x-date-pickers/DesktopDatePicker';
import Textarea from '@mui/joy/Textarea';
import react, { useState } from 'react';
import { LocalizationProvider } from '@mui/x-date-pickers';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import dayjs, { Dayjs } from 'dayjs';

export default function JobPositonForm() {
  const [value, setValue] = useState<Dayjs | null>(dayjs());

  const handleChange = (newValue: Dayjs | null) => {
    setValue(newValue);
  };
  return (
    <Container
      sx={{
        width: 600,
      }}
    >
      <Stack spacing={2}>
        <Typography variant="h5" sx={{ mb: 3 }}>
          Create a job position
        </Typography>
        <FormControl sx={{ mb: 3 }}>
          <InputLabel htmlFor="title">Title</InputLabel>
          <Input id="title" aria-describedby="job title" />
        </FormControl>
        <FormControl sx={{ mb: 3 }}>
          <InputLabel htmlFor="description">Description</InputLabel>
          <Input id="description" aria-describedby="job description" />
        </FormControl>
        <FormControl sx={{ mb: 3 }}>
          <Textarea
            minRows={4}
            placeholder="Job description..."
            variant="outlined"
          />
        </FormControl>
        <FormControl sx={{ mb: 3 }}>
          <InputLabel htmlFor="skills">Skills</InputLabel>
          <Input id="skills" aria-describedby="skills" />
        </FormControl>
        <LocalizationProvider dateAdapter={AdapterDayjs} sx={{ mt: 3 }}>
          <DesktopDatePicker
            label="Expiration Date"
            inputFormat="MM/DD/YYYY"
            value={value}
            onChange={handleChange}
            renderInput={(params) => <TextField {...params} />}
          />
        </LocalizationProvider>
        <FormControl sx={{ mt: 3 }}>
          <InputLabel htmlFor="company">Company Id</InputLabel>
          <Input id="company" aria-describedby="company" />
        </FormControl>
        <FormControl sx={{ mt: 3 }}>
          <InputLabel htmlFor="category">Category</InputLabel>
          <Input id="category" aria-describedby="category" />
        </FormControl>
        <Grid container>
          <Grid item xs={6}>
            <Button sx={{ width: '94%', mr: 2 }} variant="contained">
              Open Job Position
            </Button>
          </Grid>
          <Grid item xs={6}>
            <Button sx={{ width: '94%', ml: 2 }} variant="outlined">
              Cancel
            </Button>
          </Grid>
        </Grid>
      </Stack>
      {/* description skillSet expiryDate companyId category
        <InputLabel htmlFor="title">Skillset</InputLabel>
        <Input id="skillset" aria-describedby="skillset" />
        <FormHelperText id="my-helper-text">
          Choose a descriptive title
        </FormHelperText> */}
      {/* <TextareaAutosize minRows={10} /> */}
    </Container>
  );
}
