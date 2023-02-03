import { Box, Button, Container, Skeleton, Typography } from '@mui/material';
import FmdGoodOutlinedIcon from '@mui/icons-material/FmdGoodOutlined';
import AccessTimeOutlinedIcon from '@mui/icons-material/AccessTimeOutlined';
import CalendarTodayOutlinedIcon from '@mui/icons-material/CalendarTodayOutlined';
import CalendarMonthOutlinedIcon from '@mui/icons-material/CalendarMonthOutlined';

export default function JobPositonDetails() {
  return (
    <Container>
      <Box sx={{ display: 'flex' }}>
        <Skeleton variant="rectangular" width={100} height={100} />
        <Box sx={{ ml: 4 }}>
          <Typography variant="h3">Job Position Title</Typography>
          <span>Short Description</span>
        </Box>
      </Box>
      <Box sx={{ width: '75%' }}>
        <Typography variant="body1" sx={{ mt: 4, lineHeight: 2 }}>
          Ne kërkojmë një Software Engineer për të ndihmuar ekipin tonë në
          zhvillimin e aplikacioneve të avancuara dhe inovative. Përgjegjësitë e
          pozicionit përfshijnë projektimin, zhvillimin, testimin dhe
          mbështetjen e aplikacioneve tona duke përdorur teknologjitë Node.js,
          Express, Angular, MongoDB dhe SQL.
          <br />
          Njohja e teknologjive të mençura si Node.js, Express, Angular, MongoDB
          dhe SQL është e nevojshme, si dhe eksperienca në zhvillimin e
          aplikacioneve të webit dhe të mobilëve. Ne po kërkojmë një person që
          është i gatshëm të mësojë dhe të zhvillojë kompetencat e tij në një
          ambient të shpejtë dhe dinamik.
        </Typography>
        <Box component="div" sx={{ mt: 4, mb: 4 }}>
          <Box
            component="div"
            sx={{ display: 'flex', alignItems: 'center', mb: 2 }}
          >
            <FmdGoodOutlinedIcon sx={{ mr: 1 }} /> Prishtinë
          </Box>
          <Box
            component="div"
            sx={{ display: 'flex', alignItems: 'center', mb: 2 }}
          >
            <AccessTimeOutlinedIcon sx={{ mr: 1 }} /> Full Time
          </Box>
          <Box
            component="div"
            sx={{ display: 'flex', alignItems: 'center', mb: 2 }}
          >
            <CalendarMonthOutlinedIcon sx={{ mr: 1 }} /> 29 min ago
          </Box>
          <Box
            component="div"
            sx={{ display: 'flex', alignItems: 'center', mb: 2 }}
          >
            <CalendarTodayOutlinedIcon sx={{ mr: 1 }} /> 07/02/2023
          </Box>
        </Box>
        <Button variant="contained">Apply</Button>
      </Box>
    </Container>
  );
}
