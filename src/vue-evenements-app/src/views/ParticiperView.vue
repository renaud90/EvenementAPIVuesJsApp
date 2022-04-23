<template>
    <ParticipationForm :id="this.$route.params.id" />
</template>

<script>
import ParticipationForm from '@/components/ParticipationForm.vue'

export default {
  name: 'ParticiperView',
  components: {
    ParticipationForm
  }
}
</script>
