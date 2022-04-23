<template>
    <EvenementDetails :id="this.$route.params.id" />
</template>

<script>
import EvenementDetails from '@/components/EvenementDetails.vue'

export default {
  name: 'EvenementDetailsView',
  components: {
    EvenementDetails
  }
}
</script>
