<template>
    <BaseLayout>
        <div class="evenements">
            <h1>Liste des événements</h1>
            <EvenementsTable />
        </div>
    </BaseLayout>
</template>

<script>
import EvenementsTable from '@/components/EvenementTable.vue'
export default {
  name: 'EvenementsView',
  components: {
    EvenementsTable,
  }
}
</script>
